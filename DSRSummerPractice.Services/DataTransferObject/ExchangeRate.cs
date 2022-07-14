namespace DSR_Summer_Practice.Services.DataTransferObject
{
    /// <summary>
    /// This class defines value of the currency on a certain day
    /// </summary>
    public class ExchangeRate
    {
        public string CurrencyName { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
