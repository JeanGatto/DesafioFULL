using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Desafio.ApiPublica
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options => options.AddServerHeader = false);
                    webBuilder.UseIIS();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
