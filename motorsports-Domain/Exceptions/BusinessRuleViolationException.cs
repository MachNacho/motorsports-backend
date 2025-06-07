namespace motorsports_Domain.Exceptions
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string message, Exception ex) : base(message) { }
    }
}
