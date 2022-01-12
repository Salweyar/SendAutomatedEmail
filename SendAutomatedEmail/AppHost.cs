using Microsoft.Extensions.Configuration;
using SendAutomatedEmail.HelperClass;
using SendAutomatedEmail.Interfaces;
using SendAutomatedEmail.Models;
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

        private readonly IEmailHandler _emailHandler;

        public AppHost(IConfiguration configuration, IEmailHandler emailHandler)
        {
            _configuration = configuration;
            _emailHandler = emailHandler;
        }

        public async Task Run()
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} Starting Program");
                await RunServices();
            }
            catch (Exception ex)
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

                string from = _configuration.GetSection("From").Value;
                string to = _configuration.GetSection("To").Value;
                string cc = _configuration.GetSection("CCs").Value;
                string bcc = _configuration.GetSection("Bccs").Value;
                string name = _configuration.GetSection("Name").Value;
                string subject = _configuration.GetSection("Subject").Value;
                string username = _configuration.GetSection("UserNameForEmail").Value;
                string password = _configuration.GetSection("Password").Value;

                Tools tools = new();

                string description = tools.GetDescription();

                EmailModel model = new EmailModel
                {
                    Body = description,
                    EmailFrom = from,
                    EmailFromName = name,
                    Subject = subject,
                    Recipients = new[] { to }
                    //CCs = new[] { cc },
                    //BCCs = new[] { bcc }
                };

                if (username != null && username != "" && password != null && password != "" && to != null && to != "")
                {
                    await _emailHandler.SendEmail(model, username, password);
                }               
            }
            catch
            {
                throw;
            }
        }

    }
}
