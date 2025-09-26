using HotelListing.Configurations;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Repository;

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/hotellisting.txt", rollingInterval: RollingInterval.Day, 
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog();
    
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()   
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperInitializer>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.MapControllers();

            app.Run();
        }
    }
}