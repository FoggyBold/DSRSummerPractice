namespace DSRSummerPractice.Services.Interfaces;

using DSRSummerPractice.Services.DataTransferObject;

public interface IExchangeRateService
{
    Task<IEnumerable<ExchangeRate>> GetExchangeRates(int id, DateTime start, DateTime end);
    Task<ExchangeRate> GetExchangeRate(int id, DateTime data);
    Task<ExchangeRate> AddExchangeRate(ExchangeRate exchangeRate);
}
