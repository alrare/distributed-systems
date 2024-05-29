using Services.Products.BusinessLogic.DataAccess;
using Services.Products.Consumer.Handlers;
using Shared.Setup.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDistribtMongoDbConnectionProvider().AddScoped<IProductsReadStore, ProductsReadStore>();
builder.Services.AddTransient<IProductsReadStore, ProductsReadStore>();
builder.Services.AddServiceBusIntegrationPublisher(builder.Configuration);
builder.Services.AddHandlersInAssembly<ProductUpdatedHandler>();
builder.Services.AddServiceBusDomainConsumer(builder.Configuration);



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
