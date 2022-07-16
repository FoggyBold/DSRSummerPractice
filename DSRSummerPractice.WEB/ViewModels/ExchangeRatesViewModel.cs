namespace DSRSummerPractice.WEB.ViewModels;

public class ExchangeRatesViewModel
{
    public string CurrencyName { get; set; }
    //public IEnumerable<ExchangeRateViewModel> ExchangeRates { get; set; }
    public IEnumerable<string> Days { get; set; }
    public IEnumerable<double> Values { get; set; }
}
