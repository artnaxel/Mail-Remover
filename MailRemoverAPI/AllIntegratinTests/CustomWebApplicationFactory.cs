/*using MailRemoverAPI.Data;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace AllIntegratinTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private static Process DockerProcess => new Process
        {
            StartInfo =
        {
            UseShellExecute = false,
            FileName = "docker"
        }
        };

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the real Azure storage context registered in Startup
                var storageContext = services.SingleOrDefault(s => s.ServiceType == typeof(IStorageContext));

                if (storageContext != null)
                {
                    services.Remove(storageContext);
                }

                // Add a new context using the Azure Storage Emulator (Azurite)
                services.AddScoped<IStorageContext, StorageContext>(s => new StorageContext("UseDevelopmentStorage=true;"));

                // Pull down and run the Azurite Docker image, running just the blob storage service
                DockerProcess.Execute("pull mcr.microsoft.com/azure-storage/azurite");
                DockerProcess.Execute("run -p 10000:10000 mcr.microsoft.com/azure-storage/azurite azurite-blob --blobHost 127.0.0.1 --blobPort 10000");
            });
        }

        protected override void Dispose(bool disposing)
        {
            DockerProcess.Execute("stop mcr.microsoft.com/azure-storage/azurite");
            base.Dispose(disposing);
        }
    }

    internal static class DockerProcessExtensions
    {
        public static void Execute(this Process process, string command)
        {
            process.StartInfo.Arguments = command;
            process.Start();
            process.WaitForExit(10000);
        }
    }
}*/
