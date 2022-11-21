namespace MailRemoverAPI.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message, Guid id) : base(message + id)
        {

        }
    }
}
