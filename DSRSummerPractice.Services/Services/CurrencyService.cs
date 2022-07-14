namespace DSRSummerPractice.Services.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSRSummerPractice.Data.Context;
using DSRSummerPractice.Services.DataTransferObject;
using DSRSummerPractice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CurrencyService : ICurrencyService
{
    private readonly MainDBContext context;
    public CurrencyService(MainDBContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Currency>> GetCurrencies()
    {
        var currencies = context
            .Currencies
            .AsQueryable();

        var data = (await currencies.ToListAsync())
            .Select(currency => new Currency
            {
                CharCode = currency.CharCode,
                Name = currency.Name,
                Id = currency.ID
            });

        return data;
    }

    public async Task<Currency> GetCurrency(int id)
    {
        var currency = await context
            .Currencies
            .FirstOrDefaultAsync(el => el.ID == id);

        if(currency == null)
        {
            throw new Exception($"Currency id = {id} not found");
        }

        var data = new Currency()
        {
            CharCode = currency.CharCode,
            Name = currency.Name,
            Id = currency.ID
        };

        return data;
    }
}
