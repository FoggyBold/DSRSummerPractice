namespace DSRSummerPractice.WEB.ViewModels;

public class ExchangeRatesViewModel
{
    public int Id { get; set; }
    public string CharCode { get; set; }
    public string CurrencyName { get; set; }
    //public IEnumerable<ExchangeRateViewModel> ExchangeRates { get; set; }
    public IEnumerable<string> Days { get; set; }
    public IEnumerable<double> Values { get; set; }
}
