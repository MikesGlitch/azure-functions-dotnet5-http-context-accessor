using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpContextAccessor
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((services) =>
                {
                    services.AddHttpContextAccessor();
                })
                .Build();

            host.Run();
        }
    }
}