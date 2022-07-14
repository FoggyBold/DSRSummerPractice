namespace DSRSummerPractice.Data.Context;

using DSRSummerPractice.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class MainDBContext : DbContext
{
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<ExchangeRate> ExchangeRates { get; set; }
    public MainDBContext(DbContextOptions<MainDBContext> options)
        : base(options)
    {
    }
}