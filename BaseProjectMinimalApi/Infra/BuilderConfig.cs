
using BaseProjectMinimalApi.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace BaseProjectMinimalApi.Infra
{
    public class BuilderConfig
    {
        public static WebApplication Run()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            builder.Services.AddDbContext<AppContextDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));




            return builder.Build();
        }

        internal static void AuthenticationConfig(WebApplicationBuilder builder)
        {


        }
    }
}

