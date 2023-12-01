using BackEndStructuer.DATA.DTOs.roles;
using BackEndStructuer.Helpers;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using TextExtensions;

namespace BackEndStructuer.Controllers
{
    public class PermissionsController : BaseController
    {
        
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IRoleService _roleService;

        public PermissionsController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,IRoleService roleService)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _roleService = roleService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var groupedPermissions = _actionDescriptorCollectionProvider.ActionDescriptors.Items
            .OfType<ControllerActionDescriptor>()
            .Where(descriptor => HasAuthorizeActionFilter(descriptor))
            .GroupBy(descriptor => descriptor.ControllerName)
            .Select(group => new 
            {
                Subject = group.Key.ToKebabCase(),
                Actions = group.Select(descriptor => $"{GetCrudType(descriptor)}").Distinct()
            })
            .OrderBy(controller => controller.Subject)
            .ToList();

            var response = new
            {
                data = groupedPermissions,
            };

            return Ok(response);
        }
        
        private bool HasAuthorizeActionFilter(ControllerActionDescriptor descriptor)
        {
            return descriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ServiceFilterAttribute), true)
            .Concat(descriptor.MethodInfo.GetCustomAttributes(typeof(ServiceFilterAttribute), true))
            .Any(attr => attr is ServiceFilterAttribute serviceFilterAttr && 
                         serviceFilterAttr.ServiceType == typeof(AuthorizeActionFilter));
        }
        
        private string GetCrudType(ControllerActionDescriptor descriptor)
        {
            return descriptor.ActionName.ToKebabCase();
        }
        
        [HttpGet("my-permissions")]
        public async Task<ActionResult<AssignPermissionsDto>> MyPermissions() => Ok(await _roleService.MyPermissions(Id));
        
    }
}