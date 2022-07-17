namespace DSRSummerPractice.WEB.Controllers;

using Microsoft.AspNetCore.Mvc;
using DSRSummerPractice.Services.Interfaces;
using DSRSummerPractice.WEB.ViewModels;
using DSRSummerPractice.Services.DataTransferObject;

public class CurrencyExchangeRateDetailsController : Controller
{
    private readonly IExchangeRateService exchangeRateService;
    public CurrencyExchangeRateDetailsController(IExchangeRateService exchangeRateService)
    {
        this.exchangeRateService = exchangeRateService;
    }
    public IActionResult Index(int id, int numberOfDays = 7)
    {
        DateTime start = DateTime.Now.AddDays(-numberOfDays + 1);
        var result = exchangeRateService.GetExchangeRates(id, start, DateTime.Now).Result.ToHashSet<ExchangeRate>().ToList();

        if (result == null)
        {
            throw new Exception("Result is null");
        }

        result.Sort((x, y) =>
        {
            return x.DateTime.CompareTo(y.DateTime);
        });

        var days = new List<string>();
        var values = new List<double>();
        foreach(var value in result)
        {
            days.Add(value.DateTime.ToString().Substring(0, 10));
            values.Add(value.Value);
        }

        var exchangeRatesObj = new ExchangeRatesViewModel 
        {
            Id = id,
            CharCode = result[0].CharCode,
            CurrencyName = result[0].CurrencyName,
            Days = days,
            Values = values
        };

        return View(exchangeRatesObj);
    }
}
