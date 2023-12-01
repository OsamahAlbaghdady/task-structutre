using BackEndStructuer.DATA.DTOs.User;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("/api/Login")]
        public async Task<ActionResult> Login(LoginForm loginForm) => Ok(await _userService.Login(loginForm));
        [HttpPost("/api/Register")]
        public async Task<ActionResult> Register(RegisterForm registerForm) => Ok(await _userService.Register(registerForm));
        [HttpGet("/api/User/{id}")]
        public async Task<ActionResult> GetUser(Guid id) => OkObject(await _userService.GetUserById(id));
        [HttpPut("/api/User/{id}")]
        public async Task<ActionResult> UpdateUser(UpdateUserForm updateUserForm, Guid id) => Ok(await _userService.UpdateUser(updateUserForm,id));
        [HttpDelete("/api/User/{id}")]
        public async Task<ActionResult> DeleteUser(Guid id) => Ok(await _userService.DeleteUser(id));
        

    }
}