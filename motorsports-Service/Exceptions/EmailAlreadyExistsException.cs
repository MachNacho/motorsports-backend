namespace motorsports_Service.Exceptions
{
    public class EmailAlreadyExistsException:Exception
    {
        public EmailAlreadyExistsException() : base("Email already in use") { }
    }
}
