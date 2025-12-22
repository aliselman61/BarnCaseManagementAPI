using BarnCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BarnCase.Application.Interfaces;
using BarnCase.Application.Services;


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

// Authorization (JWT ekleyince burada devreye girecek)
app.UseAuthorization();

// Controllers map
app.MapControllers();

app.Run();
