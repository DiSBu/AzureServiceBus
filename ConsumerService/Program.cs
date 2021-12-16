using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configManager = new DIConfiguration();
            var builder = configManager.BuildConfig();
            var hostbuilder = configManager.CreateHostBuilder(args, builder.Build());
            hostbuilder.Build().Run();
        }
    }
}