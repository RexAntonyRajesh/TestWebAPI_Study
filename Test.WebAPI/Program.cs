using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Test.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static void AddMultipleJsonFiles(IConfigurationBuilder configurationBuilder)
        {
            string path = Directory.GetCurrentDirectory() + "/Configurations/";
            string[] files = System.IO.Directory.GetFiles(path, "*.json");

            foreach (var item in files)
            {
                configurationBuilder.AddJsonFile(item);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                AddMultipleJsonFiles(config);

                var builtConfig = config.Build();

            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog();
    }
}
