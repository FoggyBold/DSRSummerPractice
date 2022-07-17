namespace DSRSummerPractice.Services.Services;

using DSRSummerPractice.Data.Context;
using DSRSummerPractice.Services.DataTransferObject;
using DSRSummerPractice.Services.Interfaces;
using DSRSummerPractice.Shared.Entieties;
using DSRSummerPractice.Shared.Interfaces;
using DSRSummerPractice.Shared.Repositories;
using DSRSummerPractice.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ExchangeRateService : IExchangeRateService
{
    private readonly MainDBContext context;
    private IRepository<ValCurs> valCursRepository;
    public ExchangeRateService(MainDBContext context/*, ValCursRepository valCursRepository*/)
    {
        this.context = context;
        this.valCursRepository = new ValCursRepository(new ValCursDeserializerXML());
        //this.valCursRepository = valCursRepository;
    }

    public async Task<ExchangeRate> AddExchangeRate(ExchangeRate exchangeRate)
    {

        var currency = await context
            .Currencies
            .FirstOrDefaultAsync(el => el.CharCode == exchangeRate.CharCode);

        if (currency == null)
        {
            throw new Exception($"Currency CharCode = {exchangeRate.CharCode} not found");
        }

        var newExchangeRate = new Data.Entities.ExchangeRate()
        {
            DateTime = exchangeRate.DateTime,
            Value = exchangeRate.Value,
            Currency = currency
        };

        await context.ExchangeRates.AddAsync(newExchangeRate);
        await context.SaveChangesAsync();

        return exchangeRate;
    }

    public async Task<ExchangeRate> GetExchangeRate(int id, DateTime date)
    {
        var exchangeRate = await context
            .ExchangeRates
            .FirstOrDefaultAsync(el => el.CurrencyId == id && el.DateTime.Date == date.Date);

        if (exchangeRate != null)
        {
            return new ExchangeRate()
            {
                DateTime = date,
                Value = exchangeRate.Value,
                CurrencyName = exchangeRate.Currency.Name
            };
        }

        var currency = await context.Currencies.FirstOrDefaultAsync(el => el.ID == id);

        if (currency == null)
        {
            throw new Exception($"Currency id = {id} not found");
        }

        var answer = valCursRepository.find(date);

        if (answer == null)
        {
            throw new Exception("Service did not give an answer");
        }

        var valute = answer.Valute.FirstOrDefault(el => el.CharCode == currency.CharCode);

        if (valute == null)
        {
            throw new Exception("Answer do not have a valute");
        }

        var temp = AddExchangeRate(new ExchangeRate()
        {
            CharCode = currency.CharCode,
            DateTime = Convert.ToDateTime(answer.Date),
            Value = Convert.ToDouble(valute.Value) / valute.Nominal,
            CurrencyName = valute.Name
        }).Result;

        return temp;
    }

    public async Task<IEnumerable<ExchangeRate>> GetExchangeRates(int id, DateTime start, DateTime end)
    {
        var exchangeRates = context
            .ExchangeRates
            .Where(el => el.CurrencyId == id && el.DateTime.Date >= start.Date && el.DateTime.Date <= end.Date)
            .AsQueryable();

        var currency = await context.Currencies.FirstOrDefaultAsync(el => el.ID == id);

        var data = (await exchangeRates.ToListAsync())
            .Select(el => new ExchangeRate 
            {
                DateTime = el.DateTime,
                Value = Convert.ToDouble(el.Value),
                CurrencyName = currency.Name,
                CharCode = currency.CharCode
            })
            .ToList();

        if(data.Count() != (start - end).TotalDays)
        {
            for (var i = start; i < end; i = i.AddDays(1))
            {
                if(data.FirstOrDefault(el => el.DateTime.Date == i.Date) == null)
                {
                    var temp = GetExchangeRate(id, i);
                    data.Add(temp.Result);
                }
            }
        }

        return data;
    }
}
