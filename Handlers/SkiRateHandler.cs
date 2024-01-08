using SkiRateApi.Data;
using SkiRateApi.Models.ViewModels;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SkiRateApi.Models.DTO;
using SkiRateApi.Models;

namespace SkiRateApi.Handlers
{
    public static class SkiRateHandler
    {

        //List Skiers Name and Level in the Database

        public static IResult ListUsers(SkiContext context)
        {
            ListSkiersViewmodel[] result = 
                context.User
                .Select(u => new ListSkiersViewmodel()
                {
                    Name = u.Name,
                    Level = u.Level,
                }).ToArray();

            return Results.Json(result);
            


        }

        // Create a User and add them to the database

        public static IResult CreateUser(SkiContext context, CreateUserDTO dto)
        {

            var newUser = new User()
            {
                Name = dto.Name,
                Level = dto.Level,
                Skibrand = dto.Skibrand,
            };
            context.User.Add(newUser);
            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);

        }

        // Create a skiday with the essential intake and calculate a score

        public static IResult CreateSkiday(SkiContext context, string name, CreateSkidayDTO dto)
        {
            User? entity = context.User
            .Where(u => u.Name == name)
            .Include(u => u.Skidays)
            .SingleOrDefault();

            if (entity == null)
            {
                return Results.NotFound("User not found");
            }

            int skidayScore = SkidayScorer.CalculateSkiDayScore(dto.temperature, dto.airMoisture, dto.snowDepth, dto.windSpeedMs, dto.freshSnow, dto.liftQueueTime);

            Skiday newSkiday = new Skiday()
            {
                Location = dto.location,
                Score = skidayScore,
            };

            entity.Skidays.Add(newSkiday);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        // Get skiier name and avg skiday score

        public static IResult GetSkiAvg(SkiContext context, string name)
        {
            User? entity = context.User
            .Where(u => u.Name == name)
            .Include(u => u.Skidays)
            .SingleOrDefault();

            if (entity == null)
            {
                return Results.NotFound("User not found");
            }

            if(entity.Skidays.Count == 0)
            {
                return Results.BadRequest("No skidays available for calculation");
            }

            double avg_Skidayscore = entity.Skidays.Average(s => s.Score);

            ListSkidaysAvgViewmodel result = new ListSkidaysAvgViewmodel()
            {
                Name = entity.Name,
                Avg_Skiday = avg_Skidayscore
            };

            return Results.Json(result);



        }







    }
}
