using Microsoft.EntityFrameworkCore;
using SkiRateApi.Data;
using SkiRateApi.Handlers;

namespace SkiRateApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SkiContext");
            builder.Services.AddDbContext<SkiContext>(opt => opt.UseSqlServer(connectionString));
            var app = builder.Build();

            //Mapping the endpoints
            app.MapGet("/", () => "Welcome to the SkiRateApi");
            app.MapGet("/skiers", SkiRateHandler.ListUsers);
            app.MapPost("/createuser", SkiRateHandler.CreateUser);
            app.MapPost("/skiday/{name}", SkiRateHandler.CreateSkiday);
            app.MapGet("/skiers/{name}", SkiRateHandler.GetSkiAvg);



            app.Run();
        }
    }
}