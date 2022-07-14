namespace DSRSummerPractice.Services.Interfaces;

using DSRSummerPractice.Services.DataTransferObject;

public interface ICurrencyService
{
    Task<IEnumerable<Currency>> GetCurrencies();
    Task<Currency> GetCurrency(int id);
}
