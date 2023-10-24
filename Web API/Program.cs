using DAL;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;

namespace WebApplicationEFDEmo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BuyersContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<HouseService>();
            builder.Services.AddScoped<BuyerService>();
            builder.Services.AddScoped<MortgageApplicationService>();
            builder.Services.AddScoped<MortgageService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}