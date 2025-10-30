using motorsports_Domain.Entities;

namespace motorsports_Service.Interface
{    /// <summary>
     /// Service responsible for creating and managing JWT tokens for user authentication
     /// </summary>
    public interface ITokenService
    {    /// <summary>
         /// Creates a JWT token for the authenticated user with role-based claims
         /// </summary>
         /// <param name="user">The user entity to create the token for</param>
         /// <param name="roles">List of roles assigned to the user</param>
         /// <returns>A signed JWT token string</returns>
        string CreateToken(UserEntity user, IList<string>? roles);
    }
}
