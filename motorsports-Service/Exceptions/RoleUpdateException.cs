namespace motorsports_Service.Exceptions
{
    public class RoleUpdateException : Exception
    {
        public RoleUpdateException(string message) : base($"Failed to update user role: {message}") { }
    }
}
