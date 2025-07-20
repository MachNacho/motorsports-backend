using motorsports_Domain.Entities;

namespace motorsports_Service.Contracts
{
    public interface ITokenService
    {
        string createToken(UserEntity user);
    }
}
