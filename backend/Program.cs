using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NASA_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}






// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;


// namespace NASA_BE;

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         CreateHostBuilder(args).Build().Run();
//     }

//     public static IHostBuilder CreateHostBuilder(string[] args)
//     {
//         return Host.CreateDefaultBuilder(args)
//             .ConfigureWebHostDefaults(webBuilder =>
//             {
//                 webBuilder.UseStartup<Startup>();
//             });
//     }
// }

// public class Startup
// {
//     private readonly IConfiguration _configuration;

//     public Startup(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }

//     public void ConfigureServices(IServiceCollection services)
//     {


//         services.AddCors(options =>
//         {
//             options.AddPolicy("AllowAnyOrigin",
//         builder =>
//         {
//             builder.AllowAnyOrigin()
//                    .AllowAnyHeader()
//                    .AllowAnyMethod();
//         });
//         });

//         services.AddControllers();
//     }

//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
//     {
//         if (env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }
//         else
//         {
//             app.UseExceptionHandler(errorApp =>
//             {
//                 errorApp.Run(async context =>
//                 {
//                     context.Response.StatusCode = 500;
//                     context.Response.ContentType = "text/html";

//                     await context.Response.WriteAsync("<h1>Something went wrong!</h1>");
//                 });
//             });
//         }


//         app.UseCors("AllowAnyOrigin");

//         app.UseRouting();

//         app.UseAuthorization();

//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllers();
//         });
//     }
// }