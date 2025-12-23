using BarnCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BarnCase.Application.Interfaces;
using BarnCase.Application.Services;
using BarnCaseManagementAPI.BackgroundServices;


var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (EF Core 10)
builder.Services.AddDbContext<BarnCaseDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Application services
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSaleService, ProductSaleService>();


// Background service
builder.Services.AddHostedService<ProductProductionBackgroundService>();

// --------------------
// Build app
// --------------------

var app = builder.Build();

// --------------------
// Middleware pipeline
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
