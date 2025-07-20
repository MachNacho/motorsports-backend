
using motorsports_Domain.DTO.Account;

namespace motorsports_Service.Contracts
{
    public interface IAccountService
    {
        Task<NewUserDTO> Register(RegisterDTO user);
        Task<NewUserDTO> Login(LoginDTO user);
    }
}
