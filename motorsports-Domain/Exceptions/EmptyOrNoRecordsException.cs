namespace motorsports_Domain.Exceptions
{
    public class EmptyOrNoRecordsException : Exception
    {
        public EmptyOrNoRecordsException(string message) : base(message) { }
    }
}
