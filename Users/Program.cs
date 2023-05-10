using System;
using Users.Controllers;
using Users.Models.Context;
using Users.Models.Entities;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=GetAllUsers}/{id?}");

            app.Run();
        }

    }
}
