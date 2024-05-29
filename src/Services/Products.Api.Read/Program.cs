using Microsoft.OpenApi.Models;
using MongoDB.Driver.Core.Configuration;
using Products.Api.Read.Application;
using Products.Api.Read.Core.Context;
using Products.Api.Read.Infraestructure;
using Services.Products.BusinessLogic.DataAccess;
using System.Configuration;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // 
        builder.Services.Configure<MongoSettings>(options =>
        {
            options.ConnectionString = "mongodb://localhost:27017";
            options.Database = "Distribt";
        }
        );



        builder.Services.AddSingleton<MongoSettings>();

        builder.Services.AddTransient<IProductContext, ProductContext>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


        builder.Services.AddDistribtMongoDbConnectionProvider()
               .AddScoped<IProductsReadStore, ProductsReadStore>();

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicios.api.Libreria", Version = "v1" });
        });

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsRule", rule =>
            {
                rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}