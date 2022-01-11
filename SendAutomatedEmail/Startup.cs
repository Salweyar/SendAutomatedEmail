using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendAutomatedEmail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendAutomatedEmail
{
    class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IServiceProvider _serviceProvider;

        public Startup(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            if (string.IsNullOrEmpty(environment))
            {
                environment = "Development";
            }

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args) //Command line Arguments
                .Build();

            // Create services collection and Configure our services
            var services = ConfigureServices(_configuration);
            _serviceProvider = services.BuildServiceProvider();

        }

        public IConfiguration Configuration => _configuration;

        public IServiceProvider Provider => _serviceProvider;

        private static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);

            //Add Sql Server connection if project is using database
            //services.AddDbContext<T>(options =>
            //{
            //    string connectionString = configuration.GetConnectionString("");
            //    options.UseSqlServer(connectionString);
            //});

            //Important - Register your appkication entry point
            services.AddSingleton<IAppHost, AppHost>();
            //services.AddScoped<>();

            return services;
        }

    }
}
