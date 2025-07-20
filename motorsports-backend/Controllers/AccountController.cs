using Microsoft.AspNetCore.Mvc;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController() { }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser()
        {
            throw new NotImplementedException();
        }

        [HttpPatch("Roles")]
        public async Task<IActionResult> AssignRoles()
        {
            throw new NotImplementedException();
        }
    }
}
