using Data;
using Data.DAL;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Configuration;
using System.Reflection;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connString = builder.Configuration.GetConnectionString("SqlDbConnectionString");

            // Add services to the container.
           //builder.Services.AddSingleton<IDataAccessLayerService>(new DataAccessLayerService(connString));

            builder.Services.AddDbContext<StudentsDbContext,StudentsDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddScoped<IDataAccessLayerService, DataAccessLayerService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o=>AddSwaggerDocumentation(o));

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); // error on console 
            // Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1] An unhandled exception has occurred while executing the request. System.InvalidOperationException: Unable to resolve service for type 'Data.DAL.DataAccessLayerService' while attempting to activate 'Project.Controllers.MarksController'.*/
          
            app.UseAuthorization();





            app.MapControllers();

            app.Run();
        }

        static void AddSwaggerDocumentation(SwaggerGenOptions o)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}