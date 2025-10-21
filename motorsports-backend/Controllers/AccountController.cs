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
        [ProducesResponseType(typeof(NewUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            var user = await _accountService.RegisterAsync(registerUserDTO);
            return Ok(user);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(NewUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO login)
        {
            var user = await _accountService.LoginAsync(login);
            return Ok(user);
        }

    }
}
