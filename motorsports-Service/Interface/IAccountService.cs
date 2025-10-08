using motorsports_Service.DTOs.Account;

namespace motorsports_Service.Interface
{
    public interface IAccountService
    {
        Task<NewUserDTO> RegisterAsync(RegisterUserDTO user);
        Task<NewUserDTO> LoginAsync(LoginUserDTO user);
    }
}
