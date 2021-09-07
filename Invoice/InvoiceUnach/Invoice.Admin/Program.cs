using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Invoice.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Invoice.Admin
{
    public static class Program
    {
        private static IConfiguration BuiltConfiguration { get; set; }
        private static readonly string Namespace = typeof(Startup).Namespace;

        private static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.',
            Namespace.LastIndexOf('.') - 1) + 1);

        public static async Task Main(string[] args)
        {
            GetConfiguration();

            var host = CreateHostBuilder(args).Build();

            await host.RunAsync();
        }

        private static void GetConfiguration()
        {
            var directoryPath = Directory.GetCurrentDirectory();
            var jsonConfigFile = "appsettings.Development.json";

            BuiltConfiguration = new ConfigurationBuilder()
                .SetBasePath(directoryPath)
                .AddJsonFile(jsonConfigFile, false, true)
                .AddEnvironmentVariables()
                .Build();
        }


        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    if (BuiltConfiguration == null)
                    {
                        GetConfiguration();
                    }

                    config.AddConfiguration(BuiltConfiguration);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

            return host;
        }
    }
}