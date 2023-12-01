using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.DATA.DTOs.roles;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEndStructuer.Services
{
    public interface IRoleService
    {
         Task<(List<RoleDto>? roles, int? totalCount, string? error)> GetAll();
         
         Task<(RoleDto? role, string? error)> Add(RoleForm role);
         
         Task<(RoleDto? roleDto, string? error)> Edit(int id, RoleForm role);
         
         Task<(RoleDto? roleDto, string? error)> Delete(int id);
         
         Task<(MyPermissionsListDto? permissionsDto, string? error)> MyPermissions(Guid userId);

         Task<(string? role, string? error)> AddPermissionToRole(int roleId, AssignPermissionsDto permissions);
    }
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DataContext _dataContext;

        public RoleService( IMapper mapper, IRepositoryWrapper repositoryWrapper, DataContext dataContext)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _dataContext = dataContext;
        }

        public async Task<(List<RoleDto>? roles, int? totalCount, string? error)> GetAll()
        {
           var (data, totalCount) = await _repositoryWrapper.Role.GetAll<RoleDto>(0);
              return (_mapper.Map<List<RoleDto>>(data), totalCount, null);
        }
        public async Task<(RoleDto? role, string? error)> Add(RoleForm roleForm)
        {
            var check = await _repositoryWrapper.Role.Get<RoleDto>(x => x.Name == roleForm.Name);
            if (check != null)
            {
                return (null, "Role already exists");
            }
            
            var role = new Role()
            {
                Name = roleForm.Name
            };
            var response = await _repositoryWrapper.Role.Add(role);
            if (response == null)
            {
                return (null, "Error");
            }
            return (_mapper.Map<RoleDto>(role), null);
        }
        public async Task<(RoleDto? roleDto, string? error)> Edit(int id, RoleForm role)
        {
            var roleEntity = await _repositoryWrapper.Role.Get(x => x.Id == id);
            if (roleEntity == null)
            {
                return (null, "Role not found");
            }

            roleEntity.Name = role.Name;
            var response = await _repositoryWrapper.Role.Update(roleEntity);
            if (response == null)
            {
                return (null, "Error");
            }
            return (_mapper.Map<RoleDto>(response), null);
        }
        public async Task<(RoleDto? roleDto, string? error)> Delete(int id)
        {
            var role = await _repositoryWrapper.Role.Get(x => x.Id == id);
            if (role == null)
            {
                return (null, "Role not found");
            }

            var response = await _repositoryWrapper.Role.Delete(id);
            if (response == null)
            {
                return (null, "Error");
            }
            return (_mapper.Map<RoleDto>(response), null);
        }
        public async Task<(MyPermissionsListDto? permissionsDto, string? error)> MyPermissions(Guid userId)
        {
            var user = await _repositoryWrapper.User.Get(x => x.Id == userId, i => i.Include(r => r.Role).ThenInclude(rp => rp.RolePermissions).ThenInclude(p => p.Permission));
            if (user == null)
            {
                return (null, "User not found");
            }
            var permissions = user.Role.RolePermissions.Select(p => p.Permission.PermissionName).ToList();
            
            // group permissions by subject
            
            var groupedPermissions = permissions.GroupBy(p => p.Split('.')[0])
                .Select(group => new MyPermissionsDto
                {
                    Subject = group.Key,
                    Actions = group.Select(p => p.Split('.')[1]).Distinct()
                })
                .OrderBy(controller => controller.Subject)
                .ToList();

            var response = new MyPermissionsListDto
            {
                Data = groupedPermissions
            };
            
            return (response, null);


        }
        public async Task<(string? role, string? error)> AddPermissionToRole(int roleId, AssignPermissionsDto assignPermissions)
        {
            var role = await _repositoryWrapper.Role.Get(x => x.Id == roleId, k => k.Include(p => p.RolePermissions));
            if (role == null)
            {
                return (null, "Role not found");
            }

            var allPermissions = await _repositoryWrapper.Permission.GetAll();
            var permissionMap = allPermissions.data.ToDictionary(p => p.PermissionName, p => p);

            using var transaction = await _dataContext.Database.BeginTransactionAsync();

            try
            {
                role.RolePermissions.RemoveAll(rp => !assignPermissions.Permissions.Contains(rp.Permission.PermissionName));
                foreach (var permissionName in assignPermissions.Permissions)
                {
                    if (!role.RolePermissions.Any(rp => rp.Permission.PermissionName == permissionName))
                    {
                        if (!permissionMap.TryGetValue(permissionName, out var permissionEntity))
                        {
                            permissionEntity = new Permission { PermissionName = permissionName };
                            await _dataContext.Permissions.AddAsync(permissionEntity);
                            permissionMap.Add(permissionName, permissionEntity);
                        }
                        role.RolePermissions.Add(new RolePermission { Role = role, Permission = permissionEntity });
                    }
                }

                await _dataContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return ("done", null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (null, "An error occurred while updating role permissions.");
            }
        }
    }
}