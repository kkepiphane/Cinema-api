using Cinema_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<CinemaDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("condbcinema")));
var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("condbcinema");
}
else
{
    connection = Environment.GetEnvironmentVariable("condbcinema");
}

builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

//CinemaDbContext dbcontext = app.Services.GetRequiredService<CinemaDbContext>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
//dbcontext.Database.EnsureCreated();

app.MapControllers();

app.Run();
