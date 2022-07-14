namespace DSRSummerPractice.Data.Setup;

using DSRSummerPractice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbInit
{
    public static void Execute (IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var context = scope.ServiceProvider.GetRequiredService<MainDBContext>();
        context.Database.Migrate();
    }
}
