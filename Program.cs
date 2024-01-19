using Empleados.data;
using Empleados.Repository;
using Empleados.Service;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

namespace Empleados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IEmploymentRepository, EmploymentRepository>();
            builder.Services.AddScoped<IEmploymentService, EmploymentService>();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Empleados REST", Version = "v1" });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            {
                using var appScope = app.Services.CreateScope();
                var context = appScope.ServiceProvider.GetRequiredService<DapperContext>();
                //context.Init();
            }    
                        

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}