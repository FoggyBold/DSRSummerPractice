namespace DSRSummerPractice.WEB.Controllers;

using DSRSummerPractice.Services.Interfaces;
using DSRSummerPractice.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ICurrencyService currencyService;
    public HomeController(ICurrencyService currencyService)
    {
        this.currencyService = currencyService;
    }
    public IActionResult Index()
    {
        var currencies = currencyService.GetCurrencies().Result;
        CurrenciesViewModel currenciesObj = new CurrenciesViewModel
        {
            currencies = currencies
        };
        return View(currenciesObj);
    }
}