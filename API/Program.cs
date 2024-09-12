using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AraOdemeContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<LoanCalculationService>();
builder.Services.AddScoped<AraOdemeService>();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();  // Only if using authorization

app.MapControllers();    // Maps controllers to endpoints

app.Run();
