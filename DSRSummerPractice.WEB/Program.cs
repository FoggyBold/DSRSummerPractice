using DSRSummerPractice.Data.Context;
using DSRSummerPractice.Data.Setup;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MainDbContext");

builder.Services.AddDbContext<MainDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});


builder.Services.AddControllers();

// Configure the HTTP request pipeline.

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();


DbInit.Execute(app.Services);

DbSeed.Execute(app.Services);


app.Run();
