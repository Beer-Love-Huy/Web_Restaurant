using AutoMapper;
using MenuAPI.Infrastructure.Middleware;
using MenuAPI.Models.Context;
using MenuAPI.Models.Mapping;
using MenuAPI.Repositories.Inplementations;
using MenuAPI.Repositories.Interface;
using MenuAPI.Services.Implementations;
using MenuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Register application services
builder.Services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
builder.Services.AddScoped<IFoodTypeService, FoodTypeService>();

builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program), typeof(FoodTypeProfile));
builder.Services.AddAutoMapper(typeof(Program), typeof(FoodProfile));
// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Menu API",
        Version = "v1",
        Description = "API for managing food types",
        Contact = new OpenApiContact
        {
            Name = "Developer Team",
            Email = "developer@example.com",
            Url = new Uri("https://example.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Menu API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI as the root page
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
