using Microsoft.Extensions.Configuration;
using SendAutomatedEmail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendAutomatedEmail
{
    public class AppHost : IAppHost
    {
        private readonly IConfiguration _configuration;

        public AppHost(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Run()
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} Starting Program");
                await RunServices();
            }
            catch(Exception ex)
            {
                var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
                if (string.IsNullOrEmpty(environment))
                {
                    environment = "Development";
                }

                Console.WriteLine($"{DateTime.Now}Unexpected error occured {environment} environment: {ex.Message}");

            }
            Console.WriteLine($"{DateTime.Now} Done");
        }

        public async Task RunServices()
        {
            try
            {
                Console.WriteLine($"Test Running...");

            }
            catch
            {
                throw;
            }
        }

    }
}
