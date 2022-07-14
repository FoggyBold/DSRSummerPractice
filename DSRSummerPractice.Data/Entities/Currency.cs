namespace DSRSummerPractice.Data.Entities;

/// <summary>
/// This class defines entitie of currency
/// </summary>
public class Currency
{
    public int ID { get; set; }
    public string Name { get; set; }

    public IEnumerable<ExchangeRate> ExchangeRates { get; set; }
}
