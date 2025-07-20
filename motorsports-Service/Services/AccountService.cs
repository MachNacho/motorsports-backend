using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.DTO.Account;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;

namespace motorsports_Service.Services
{
    public class AccountService:IAccountService
    {
        //User identity manager
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        //Token service
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ITokenService tokenService) {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<NewUserDTO> Login(LoginDTO login)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName== login.Username.ToUpper());
            if (user == null) { /*tHROW SOMETHING FOR USERNAME INVALID*/}
            var result = await _signInManager.CheckPasswordSignInAsync(user,login.Password,false);

            if (!result.Succeeded) { /*throw something for incorrrect password*/}

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

            var userEmail = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email == register.Email);

            if (userEmail != null) {/*Throw something for identical email*/ }

            var createdUser = await _userManager.CreateAsync(createUser, register.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(createUser,"User");
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
                    /*Throw something for role error*/
                }
            }
            else
            {
                //Throw error for unsccessful account creation
            }
                throw new NotImplementedException();
        }
    }
}
