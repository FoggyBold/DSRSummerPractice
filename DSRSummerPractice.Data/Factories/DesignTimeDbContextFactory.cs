namespace DSRSummerPractice.Data.Factories;

using DSRSummerPractice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDBContext>
{
    public MainDBContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.Development.json")
             .Build();

        var options = new DbContextOptionsBuilder<MainDBContext>()
                      .UseSqlServer(configuration.GetConnectionString("MainDbContext")).Options;

        return new MainDBContext(options);
    }
}
