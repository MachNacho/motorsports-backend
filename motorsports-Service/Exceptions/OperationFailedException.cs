namespace motorsports_Service.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException(string message) : base(message) { }
    }
}
