namespace DSRSummerPractice.Data.Setup;

using DSRSummerPractice.Data.Context;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeed
{
    private static void AddBooks(MainDBContext context)
    {
        if(context.Currencies.Any())
        {
            return;
        }

        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "AUD",
            Name = "Австралийский доллар"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "AZN",
            Name = "Азербайджанский манат"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "GBP",
            Name = "Фунт стерлингов Соединенного королевства"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "AMD",
            Name = "Армянский драм"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "BYN",
            Name = "Белорусский рубль"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "BGN",
            Name = "Болгарский лев"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "BRL",
            Name = "Бразильский реал"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "HUF",
            Name = "Венгерский форинт"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "HKD",
            Name = "Гонконгский доллар"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "DKK",
            Name = "Датская крона"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "USD",
            Name = "Доллар США"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "EUR",
            Name = "Евро"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "INR",
            Name = "Индийских рупий"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "KZT",
            Name = "Казахстанский тенге"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "CAD",
            Name = "Канадский доллар"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "KGS",
            Name = "Киргизский сом"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "CNY",
            Name = "Китайский юань"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "MDL",
            Name = "Молдавских леев"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "NOK",
            Name = "Молдавский лей"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "PLN",
            Name = "Польский злотый"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "RON",
            Name = "Румынский лей"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "XDR",
            Name = "СДР"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "SGD",
            Name = "Сингапурский доллар"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "TJS",
            Name = "Таджикский сомони"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "TRY",
            Name = "Турецкая лира"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "TMT",
            Name = "Новый туркменский манат"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "UZS",
            Name = "Узбекский сум"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "UAH",
            Name = "Гривна"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "CZK",
            Name = "Чешская крона"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "SEK",
            Name = "Шведская крона"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "CHF",
            Name = "Швейцарский франк"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "ZAR",
            Name = "Южноафриканский рэнд"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "KRW",
            Name = "Южнокорейская вона"
        });
        context.Currencies.Add(new Entities.Currency()
        {
            CharCode = "JPY",
            Name = "Японская йена"
        });
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
