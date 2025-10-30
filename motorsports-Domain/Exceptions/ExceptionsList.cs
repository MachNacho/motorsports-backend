namespace motorsports_Domain.Exceptions
{
    #region DB exceptions
    public class RecordNotFound : Exception
    {
        public RecordNotFound() : base("The record was not found") { }
        public RecordNotFound(string message) : base(message) { }
    }
    #endregion

    #region Account exceptions
    public class UserNotFound : Exception
    {
        public UserNotFound() : base("User not found") { }
        public UserNotFound(string message) : base(message) { }
    }

    public class PasswordMismatch : Exception
    {
        public PasswordMismatch() : base("Password not the same") { }
        public PasswordMismatch(string message) : base(message) { }
    }

    public class DuplicateUserEmail : Exception
    {
        public DuplicateUserEmail() : base("There is a duplicate user email") { }
        public DuplicateUserEmail(string message) : base(message) { }
    }

    public class UserCreationError : Exception
    {
        public UserCreationError() : base("There was an issue creating the user") { }
        public UserCreationError(string message) : base(message) { }
    }

    public class UserRoleCreationError : Exception
    {
        public UserRoleCreationError() : base("There was an issue assigning a role to a user") { }
        public UserRoleCreationError(string message) : base(message) { }
    }

    public class DuplicateUsernameException : Exception
    {
        public DuplicateUsernameException() : base("There is a duplicate username") { }
        public DuplicateUsernameException(string message) : base(message) { }
    }
    #endregion
}