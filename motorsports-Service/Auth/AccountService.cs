using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
using motorsports_Service.DTOs.Account;
using motorsports_Service.Interface;

namespace motorsports_Service.Auth
{
    public class AccountService : IAccountService
    {
        //User identity manager
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //Token service
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<NewUserDTO> LoginAsync(LoginUserDTO login)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == login.Username.ToUpper());
            if (user == null) { throw new UserNotFound(); }
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) { throw new PasswordMismatch(); }

            return new NewUserDTO
            {
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.createToken(user)
            };
        }

        public async Task<NewUserDTO> RegisterAsync(RegisterUserDTO register)
        {
            var createUser = new UserEntity
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Username,
            };

            var userEmail = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == register.Email);

            if (userEmail != null) { throw new DuplicateUserEmail(); }

            var createdUser = await _userManager.CreateAsync(createUser, register.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(createUser, "User");
                if (roleResult.Succeeded)
                {
                    return new NewUserDTO
                    {
                        Username = createUser.UserName,
                        Email = createUser.Email,
                        userId = createUser.Id,
                        Token = _tokenService.createToken(createUser)
                    };
                }
                else
                {
                    throw new UserRoleCreationError();
                }
            }
            else
            {
                throw new UserCreationError();
            }
        }
    }
}
