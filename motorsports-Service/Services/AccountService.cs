using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.DTO.Account;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.Exceptions;

namespace motorsports_Service.Services
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

        public async Task<NewUserDTO> Login(LoginDTO login)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == login.Username.ToUpper());
            if (user == null) { throw new AuthenticationFailedException(); }
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) { throw new AuthenticationFailedException(); }

            return new NewUserDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.createToken(user)
            };
        }

        public async Task<NewUserDTO> Register(RegisterDTO register)
        {
            var createUser = new UserEntity
            {
                FirstName = register.UserFirstName,
                LastName = register.UserLastName,
                Email = register.Email,
                UserName = register.Username,
            };

            var userEmail = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == register.Email);

            if (userEmail != null) { throw new EmailAlreadyExistsException(); }

            var createdUser = await _userManager.CreateAsync(createUser, register.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(createUser, "User");
                if (roleResult.Succeeded)
                {
                    return new NewUserDTO
                    {
                        UserName = createUser.UserName,
                        Email = createUser.Email,
                        userID = createUser.Id,
                        Token = _tokenService.createToken(createUser)
                    };
                }
                else
                {
                    throw new UserCreationFailedException("Failed to create user.");
                }
            }
            else
            {
                throw new UserCreationFailedException("Failed to create user.");
            }
        }

        public async Task RoleChange(UpdateUserRoleDTO userRoleUpdate)
        {
            //Find the user
            var user = await _userManager.FindByIdAsync(userRoleUpdate.UserId);
            if (user == null) throw new UserNotFoundException(userRoleUpdate.UserId);

            if (!await _roleManager.RoleExistsAsync(userRoleUpdate.NewRole)) throw new RoleNotFoundException(userRoleUpdate.NewRole);

            var currentRole = await _userManager.GetRolesAsync(user);

            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRole);
            if (!removeResult.Succeeded)
            {
                var errors = string.Join(", ", removeResult.Errors.Select(e => e.Description));
                throw new RoleUpdateException(errors);
            }
            ;

            var addResult = await _userManager.AddToRoleAsync(user, userRoleUpdate.NewRole);

            if (!addResult.Succeeded)
            {
                var errors = string.Join(", ", addResult.Errors.Select(e => e.Description));
                throw new RoleUpdateException(errors);
            }
            ;
        }
    }
}
