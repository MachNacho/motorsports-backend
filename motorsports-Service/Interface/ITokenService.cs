using motorsports_Domain.Entities;

namespace motorsports_Service.Interface
{
    public interface ITokenService
    {
        string createToken(UserEntity user);
    }
}
