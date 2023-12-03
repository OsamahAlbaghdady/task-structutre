using AutoMapper;
using BackEndStructuer.DATA.DTOs.User;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using e_parliament.Interface;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.Services
{
    public interface IUserService
    {
        Task<(UserDto? user, string? error)> Login(LoginForm loginForm);
        Task<(AppUser? user, string? error)> DeleteUser(Guid id);
        Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm);
        Task<(AppUser? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid id);

        Task<(UserDto? user, string? error)> GetUserById(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<(UserDto? user, string? error)> Login(LoginForm loginForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.Email == loginForm.Email, i => i.Include(x => x.Role));
            if (user == null) return (null, "User not found");
            if (!BCrypt.Net.BCrypt.Verify(loginForm.Password, user.Password)) return (null, "Wrong password");
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _tokenService.CreateToken(user);
            return (userDto, null);
        }

        public async Task<(AppUser? user, string? error)> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm)
        {
            var role = await _repositoryWrapper.Role.Get(r => r.Id == registerForm.Role);
            if (role == null) return (null, "Role not found");


            var user = await _repositoryWrapper.User.Get(u => u.Email == registerForm.Email);
            if (user != null) return (null, "User already exists");
            var newUser = new AppUser
            {
                Email = registerForm.Email,
                FullName = registerForm.FullName,
                Password = BCrypt.Net.BCrypt.HashPassword(registerForm.Password),
                RoleId = role.Id
            };
            // set role 

            var finalUser = await _repositoryWrapper.User.CreateUser(newUser);
            var userDto = _mapper.Map<UserDto>(finalUser);
            userDto.Token = _tokenService.CreateToken(newUser);
            return (userDto, null);
        }

        public async Task<(AppUser? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid id)
        {
            var user = await _repositoryWrapper.User.Get(u => u.Id == id);
            if (user == null) return (null, "User not found");
            if (user.Email != updateUserForm.Email) user.Email = updateUserForm.Email;
            if (user.FullName != updateUserForm.FullName) user.FullName = updateUserForm.FullName;
            await _repositoryWrapper.User.UpdateUser(user);
            return (user, null);
        }

        public async Task<(UserDto? user, string? error)> GetUserById(Guid id)
        {
            var user = await _repositoryWrapper.User.Get(u => u.Id == id);
            if (user == null) return (null, "User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }
    }
}