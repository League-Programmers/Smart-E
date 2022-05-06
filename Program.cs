using Microsoft.AspNetCore;
using Smart_E;


namespace Smart_E
{


    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new WebHostBuilder().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    /* setup config */
                }).ConfigureLogging((hostingContext, logging) =>
                {
                    /* setup logging */
                }).UseIISIntegration();
            return builder;
        }

    }
}

