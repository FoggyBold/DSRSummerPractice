namespace DSRSummerPractice.WEB.Controllers;

using Microsoft.AspNetCore.Mvc;
using DSRSummerPractice.Services.Interfaces;
using DSRSummerPractice.WEB.ViewModels;


public class CurrencyExchangeRateDetailsController : Controller
{
    private readonly IExchangeRateService exchangeRateService;
    public CurrencyExchangeRateDetailsController(IExchangeRateService exchangeRateService)
    {
        this.exchangeRateService = exchangeRateService;
    }
    public IActionResult Index(int id)
    {
        DateTime start = DateTime.Now.AddDays(-7);
        var result = exchangeRateService.GetExchangeRates(id, start, DateTime.Now).Result.ToList();

        if (result == null)
        {
            throw new Exception("Result is null");
        }

        //var temp = new List<ExchangeRateViewModel>();
        //foreach(var item in result)
        //{
        //    temp.Add(new ExchangeRateViewModel
        //    {
        //        DateTime = item.DateTime,
        //        Value = item.Value
        //    });
        //}
        //var exchangeRatesObj = new ExchangeRatesViewModel
        //{
        //    CurrencyName = result[0].CurrencyName,
        //    ExchangeRates = temp
        //};
        var days = new List<string>();
        var values = new List<double>();
        foreach(var value in result)
        {
            days.Add(value.DateTime.Date.ToString().Substring(0,10));
            values.Add(value.Value);
        }
        var exchangeRatesObj = new ExchangeRatesViewModel 
        {
            CurrencyName = result[0].CurrencyName,
            Days = days,
            Values = values
        };

        return View(exchangeRatesObj);
    }
}
