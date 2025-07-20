namespace motorsports_Service.Exceptions
{
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException(string message) : base(message) { }
    }
}
