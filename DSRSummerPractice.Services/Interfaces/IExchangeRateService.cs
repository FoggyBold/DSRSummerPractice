using DSR_Summer_Practice.Services.DataTransferObject;

namespace DSR_Summer_Practice.Services.Interfaces
{
    public interface IExchangeRateService
    {
        IEnumerable<ExchangeRate> GetExchangeRates(int id, DateTime start, DateTime end);
        IEnumerable<Currency> GetCurrencies();
    }
}
