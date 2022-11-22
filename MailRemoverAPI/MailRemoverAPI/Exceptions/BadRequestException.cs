namespace MailRemoverAPI.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message, string id = "No id") : base(message + id)
        {

        }
    }
}
