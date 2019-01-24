using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel((context, options) =>
                {
                    options.Listen(IPAddress.Loopback,  5000);
                    options.Listen(IPAddress.Loopback, 5001, listenOptions => 
                    { 
                        listenOptions.UseHttps("localhost.pfx", "Random77PrimoLucky"); 
                    });
                })
                .UseStartup<Startup>();
    }
}