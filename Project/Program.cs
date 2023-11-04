using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
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
            builder.Services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(connString));
            //builder.Services.AddDataAccessLayer(connString);
            // builder.Services.AddSingleton<StudentsDbContext>();
            builder.Services.AddScoped<StudentsDbContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o=>AddSwaggerDocumentation(o));

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DefaultModelsExpandDepth(-1); //To reset the Schemas from previous session - its ok?
                });
            }

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