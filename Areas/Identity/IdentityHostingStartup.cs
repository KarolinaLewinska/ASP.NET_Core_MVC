using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StudentsDataSystem.Areas.Identity.IdentityHostingStartup))]
namespace StudentsDataSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}