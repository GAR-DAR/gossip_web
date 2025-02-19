using Backend.Services;
using Backend.Hubs;
using Microsoft.Extensions.Configuration;  // для доступу до конфігурації
using System;

namespace Backend
{
    public class Program
    {
        public static class Globals
        {
            public static readonly IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            public static DatabaseService db = new DatabaseService();
            //public static readonly TokenProvider tokenProvider = new TokenProvider(configuration);
        }

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",");

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(allowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();

            app.MapHub<ChatHub>("/chat");
            app.MapControllers();

            app.Run();
        }
    }
}
