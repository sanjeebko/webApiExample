
using Microsoft.EntityFrameworkCore;
using NZWalks.API.AutoMapper;
using NZWalks.API.Data;
using NZWalks.API.Repository;
using Scalar.AspNetCore;

namespace NZWalks.API;

public class Program
{
    //OPENAPI json file
    //https://localhost:7191/openapi/v1.json
    //To export user-secrets
    //dotnet user-secrets --project NZWalks.API list --json > user-secrets.json

    //To import in another server.
    //dotnet user-secrets init --project NZWalks.API
    //dotnet user-secrets set < user-secrets.json --project NZWalks.API

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        string connectionString = GetConnectionString(builder);

        builder.Services.AddDbContext<NZWalksDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
        builder.Services.AddScoped<IWalkRepository, WalkRepository>();

        builder.Configuration.AddUserSecrets<Program>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference();
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    private static string GetConnectionString(WebApplicationBuilder builder)
    {
        var defaultConnectionString = builder.Configuration.GetConnectionString("NZWalksConnectionString");
        var dbServer = builder.Configuration["sqlserver"] ?? "localhost";
        var dbPassword = builder.Configuration["sapassword"] ?? "dummyPassword";
        var connectionString = $"Server={dbServer};{defaultConnectionString} Password={dbPassword};";
        return connectionString;
    }
}
