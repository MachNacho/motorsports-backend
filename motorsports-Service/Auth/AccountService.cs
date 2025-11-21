using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Constants;
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
        //Logging
        private readonly ILogger<AccountService> _logger;

        public AccountService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService, ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<string> LoginAsync(LoginUserDTO loginDTO)
        {
            // Validate input
            if (loginDTO == null)
            {
                throw new ArgumentNullException(nameof(loginDTO));
            }
            if (string.IsNullOrWhiteSpace(loginDTO.Username) || string.IsNullOrWhiteSpace(loginDTO.Password))
            {
                _logger.LogWarning("Login attempt with empty credentials");
                throw new ArgumentException("Username and password are required");
            }

            //Looking for user based on username
            var user = await _userManager.FindByNameAsync(loginDTO.Username);

            if (user == null)
            {
                _logger.LogWarning("Login failed: User not found - {Username}", loginDTO.Username);
                throw new UserNotFound();
            }


            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!signInResult.Succeeded) { throw new PasswordMismatch(); }

            //Get user role
            var userRoles = await _userManager.GetRolesAsync(user);

            string Token = _tokenService.CreateToken(user, userRoles);
            return Token;
        }

        public async Task<string> RegisterAsync(RegisterUserDTO registerDTO)
        {
            if (registerDTO == null)
            {
                throw new ArgumentNullException(nameof(registerDTO));
            }

            //Check if values are duplicated
            var existingUserByEmail = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (existingUserByEmail != null)
            {
                _logger.LogWarning("Registration failed: Email already exists - {Email}", registerDTO.Email);
                throw new DuplicateUserEmail();
            }
            var existingUserByUsername = await _userManager.FindByNameAsync(registerDTO.Username);
            if (existingUserByUsername != null)
            {
                _logger.LogWarning("Registration failed: Username already exists - {Username}", registerDTO.Username);
                throw new DuplicateUsernameException();
            }

            var newUser = new UserEntity
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
            };

            var createdUserResult = await _userManager.CreateAsync(newUser, registerDTO.Password);

            if (!createdUserResult.Succeeded)
            {
                _logger.LogError("User creation failed for {Email}: {Errors}", registerDTO.Email, string.Join(",", createdUserResult.Errors.Select(e => e.Description)));

                throw new UserCreationError();
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(newUser, Constants.DEFAULT_ADMIN_ROLE);

            if (!addToRoleResult.Succeeded)
            {
                _logger.LogError("Role assignment failed for user {Email}: {Errors}", registerDTO.Email, string.Join(", ", addToRoleResult.Errors.Select(e => e.Description)));

                // Cleanup: Delete the created user if role assignment fails
                await _userManager.DeleteAsync(newUser);

                throw new UserRoleCreationError();
            }
            var userRole = await _userManager.GetRolesAsync(newUser);

            // Generate and return JWT token
            string Token = _tokenService.CreateToken(newUser, userRole);

            return Token;
        }
    }
}
