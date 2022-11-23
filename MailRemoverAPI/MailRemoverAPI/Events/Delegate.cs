namespace MailRemoverAPI.Events
{
    public class Delegate
    {
        public delegate void AccessTokenExpiredEventHandler<T, U>(T source, U args);
    }
}
