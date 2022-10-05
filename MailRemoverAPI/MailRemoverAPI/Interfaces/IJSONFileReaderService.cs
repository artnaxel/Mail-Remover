using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Interfaces
{
    public interface IJSONFileReaderService
    {
        public Task<List<T>> ReadAll<T>()
             where T : Entity;
    }
}
