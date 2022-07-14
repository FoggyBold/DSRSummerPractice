using DSRSummerPractice.Data.Context;
using DSRSummerPractice.Data.Setup;
using DSRSummerPractice.Services.Interfaces;
using DSRSummerPractice.Services.Services;
using DSRSummerPractice.Shared.Entieties;
using DSRSummerPractice.Shared.Interfaces;
using DSRSummerPractice.Shared.Repositories;
using DSRSummerPractice.Shared.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MainDbContext");

builder.Services.AddDbContext<MainDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddControllers();

//builder.Services.AddScoped<IDeserializerXML<ValCurs>, ValCursDeserializerXML>();

//builder.Services.AddScoped<IRepository<ValCurs>, ValCursRepository>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();

// Configure the HTTP request pipeline.

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}"
    );
});

DbInit.Execute(app.Services);

DbSeed.Execute(app.Services);

app.Run();
