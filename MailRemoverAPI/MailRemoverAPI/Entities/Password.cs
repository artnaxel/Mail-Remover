namespace MailRemoverAPI.Entities
{
    public struct Password
    {
        public String PasswordStr { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsExpired()
        {
            if (ExpirationDate > DateTime.Now)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
