
using Microsoft.EntityFrameworkCore;
using NLayers.BusinessLogic.Contracts;
using NLayers.BusinessLogic.Managers;
using NLayers.DataAccess;
using NLayers.DataAccess.Contracts;
using NLayers.DataAccess.Stores;

namespace NLayers.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Inyeccion de Managers y Stores;
            builder.Services.AddScoped<IDummyManager, DummyManager>();
            builder.Services.AddScoped<IDummyStore, DummyStore>();

            //Inyeccion de DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NLayersDatabase;Integrated Security=True;");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
