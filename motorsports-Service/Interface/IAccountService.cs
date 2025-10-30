using motorsports_Service.DTOs.Account;

namespace motorsports_Service.Interface

{   /// <summary>
    /// Service for managing user authentication and registration operations.
    /// Handles user login, registration, and token generation.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Registers a new user account and assigns default role.
        /// </summary>
        /// <param name="registerDto">User registration information</param>
        /// <returns>JWT authentication token for the newly created user</returns>
        /// <exception cref="DuplicateUserEmail">Thrown when email already exists</exception>
        /// <exception cref="UserCreationError">Thrown when user creation fails</exception>
        /// <exception cref="UserRoleCreationError">Thrown when role assignment fails</exception>
        /// <exception cref="ArgumentNullException">Thrown when registerDto is null</exception>
        Task<string> RegisterAsync(RegisterUserDTO user);

        /// <summary>
        /// Authenticates a user and generates a JWT token upon successful login.
        /// </summary>
        /// <param name="loginDto">Login credentials containing username and password</param>
        /// <returns>JWT authentication token</returns>
        /// <exception cref="UserNotFound">Thrown when user doesn't exist</exception>
        /// <exception cref="PasswordMismatch">Thrown when password is incorrect</exception>
        /// <exception cref="ArgumentNullException">Thrown when loginDto is null</exception>
        Task<string> LoginAsync(LoginUserDTO user);
    }
}
