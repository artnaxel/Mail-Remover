using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using System.Text.Json;

namespace MailRemoverAPI.Services
{
    public class JSONFileReaderService : IJSONFileReaderService
    {
        private IConfiguration _configuration;

        public JSONFileReaderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> ReadAll<T>()
            where T : Entity
        {

            var filePath = Directory.GetCurrentDirectory() + _configuration["JSONFilesLocation"] + GetEntityFileName<T>();

            Console.WriteLine(filePath);

            using FileStream stream = File.OpenRead(filePath);

            var entries = await JsonSerializer.DeserializeAsync<List<T>>(stream);

            if (entries is null)
            {
                throw new Exception("File is completely empty or was not set up correctly");
            }

            return entries;
        }

        private string GetEntityFileName<T>()
            where T : Entity
        {
            var entityType = typeof(T).ToString().Split(".")[2];
            var filename = _configuration[$"JSONFileNames:{entityType}"];

            if(filename == null)
            {
                throw new FileNotFoundException($"There is no JSON filename in enviroment settings as {entityType}.json");
            }

            return filename;
        }
    }
}
