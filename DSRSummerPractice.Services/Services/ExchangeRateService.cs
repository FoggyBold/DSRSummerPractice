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
            .FirstOrDefaultAsync(el => el.CurrencyId == id && el.DateTime == date);

        if(exchangeRate == null)
        {
            var currency = await context.Currencies.FirstOrDefaultAsync(el => el.ID == id);
            
            if (currency == null)
            {
                throw new Exception($"Currency id = {id} not found");
            }

            var answer = valCursRepository
                .find(date)
                .Valute
                .FirstOrDefault(el => el.CharCode == currency.CharCode);
            
            if(answer == null)
            {
                throw new Exception("Service did not give an answer");
            }

            var temp = AddExchangeRate(new ExchangeRate()
            {
                CharCode = currency.CharCode,
                DateTime = date,
                Value = Convert.ToDouble(answer.Value)
            }).Result;

            exchangeRate = new Data.Entities.ExchangeRate()
            {
                Currency = currency,
                Value = temp.Value,
                DateTime = date
            };
        }
        
        var data = new ExchangeRate()
        {
            DateTime = date,
            Value = exchangeRate.Value,
            CurrencyName = exchangeRate.Currency.Name
        };

        return data;
    }

    public async Task<IEnumerable<ExchangeRate>> GetExchangeRates(int id, DateTime start, DateTime end)
    {
        var exchangeRates = context
            .ExchangeRates
            .Where(el => el.CurrencyId == id && el.DateTime >= start && el.DateTime <= end)
            .AsQueryable();

        var data = (await exchangeRates.ToListAsync())
            .Select(el => new ExchangeRate 
            {
                DateTime = el.DateTime,
                Value = Convert.ToDouble(el.Value),
                CurrencyName = el.Currency.Name,
                CharCode = el.Currency.CharCode
            })
            .ToList();

        if(data.Count() != (start - end).TotalDays)
        {
            List<DateTime> dates = new();
            if(data.Count == 0)
            {
                for (var i = start; i < end; i = i.AddDays(1))
                {
                    dates.Add(i);
                }
            }
            else
            {
                DateTime currDate = start;
                foreach (var el in data)
                {
                    while (el.DateTime != currDate && currDate != end)
                    {
                        dates.Add(currDate);
                        currDate = currDate.AddDays(1);
                    }
                }
            }

            foreach(var date in dates)
            {
                var temp = GetExchangeRate(id, date).Result;
                data.Add(temp);
                await AddExchangeRate(temp);
            }
        }

        return data;
    }
}
