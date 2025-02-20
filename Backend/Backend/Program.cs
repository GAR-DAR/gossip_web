using Backend.Services;
using Backend.Hubs;
using Microsoft.Extensions.Configuration;  // ��� ������� �� ������������
using System;
using Microsoft.AspNetCore.SignalR;
using Backend.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Backend.Extentions;

namespace Backend
{
    public class Program
    {
        public static class Globals
        {
            public static readonly IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            public static DatabaseService db = new DatabaseService();
            public static readonly TokenProvider tokenProvider = new TokenProvider(configuration);
        }

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGenWithAuth();

            //builder.Services.AddSingleton<PasswordHasher>();
            builder.Services.AddSingleton<TokenProvider>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ModeratorPolicy", policy => policy.RequireRole("Moderator"));
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero

                };
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapHub<ChatHub>("/chat");
            app.MapControllers();
            app.Run();
        }
    }
}
