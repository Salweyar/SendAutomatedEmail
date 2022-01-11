
using Microsoft.Extensions.DependencyInjection;
using SendAutomatedEmail.Interfaces;

namespace SendAutomatedEmail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var startup = new Startup(args);

            var service = startup.Provider.GetRequiredService<IAppHost>();

            await service.Run();
        }
    }
}