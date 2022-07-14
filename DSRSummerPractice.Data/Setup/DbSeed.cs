namespace DSRSummerPractice.Data.Setup;

using DSRSummerPractice.Data.Context;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeed
{
    private static void AddBooks(MainDBContext context)
    {
        context.SaveChanges();
    }

    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var context = scope.ServiceProvider.GetRequiredService<MainDBContext>();
        AddBooks(context);
    }
}
