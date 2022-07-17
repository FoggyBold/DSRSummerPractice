using System.Collections;

namespace DSRSummerPractice.Services.DataTransferObject;

/// <summary>
/// This class defines value of the currency on a certain day
/// </summary>
public class ExchangeRate
{
    public string CharCode { get; set; }
    public string CurrencyName { get; set; }
    public DateTime DateTime { get; set; }
    public double Value { get; set; }

    public override bool Equals(Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            ExchangeRate p = (ExchangeRate)obj;
            return Value == p.Value;
        }
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}