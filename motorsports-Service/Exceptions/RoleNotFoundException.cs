namespace motorsports_Service.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException(string roleName) : base($"Role '{roleName}' does not exist.") { }
    }
}
