namespace motorsports_Domain.Exceptions
{
    public class ExceptionsList
    {
        public class RecordNotFound : Exception
        {
            public RecordNotFound(string message) : base(message) { }
        }
    }
}