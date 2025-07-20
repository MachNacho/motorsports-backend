using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.DTO.Account;
using motorsports_Service.Contracts;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) { _accountService = accountService; }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO register)
        {
            return Ok(await _accountService.Register(register));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO login)
        {
            return Ok(await _accountService.Login(login));
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> AssignRoles([FromBody] UpdateUserRoleDTO update)
        {
            await _accountService.RoleChange(update);
            return Ok();
        }
    }
}
