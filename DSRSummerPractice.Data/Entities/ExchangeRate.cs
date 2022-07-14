namespace DSRSummerPractice.Data.Entities;

/// <summary>
/// This class defines value of the currency on a certain day
/// </summary>
public class ExchangeRate
{
    public int ID { get; set; }
    public DateTime DateTime { get; set; }
    public double Value { get; set; }

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
}
