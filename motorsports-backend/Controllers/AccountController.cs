using Microsoft.AspNetCore.Mvc;
using motorsports_Service.DTOs.Account;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) { _accountService = accountService; }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            var a = await _accountService.RegisterAsync(registerUserDTO);
            return Ok(a);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO login)
        {
            var a = await _accountService.LoginAsync(login);
            return Ok(a);
        }

    }
}
