namespace MailRemoverAPI.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Guid key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
