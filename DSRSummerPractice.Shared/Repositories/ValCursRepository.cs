namespace DSRSummerPractice.Shared.Repositories;

using DSRSummerPractice.Shared.Entieties;
using DSRSummerPractice.Shared.Interfaces;

public class ValCursRepository : IRepository<ValCurs>
{
    private IDeserializerXML<ValCurs> deserializerXML;
    private string url = "http://www.cbr.ru/scripts/XML_daily.asp";
    public ValCursRepository(IDeserializerXML<ValCurs> deserializerXML)
    {
        this.deserializerXML = deserializerXML;
    }

    /// <summary>
    /// Returns a list of currencies for a certain period of days
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of valCurs</returns>
    public IEnumerable<ValCurs> find(DateTime start, DateTime end)
    {
        List<ValCurs> res = new List<ValCurs>();
        for(var i = start; i<= end; i = i.AddDays(1))
        {
            res.Add(deserialize(i));
        }
        return res;
    }

    private ValCurs deserialize(DateTime date)
    {
        string day = date.Day.ToString().Length == 1 ? $"0{date.Day}" : date.Day.ToString();
        string month = date.Month.ToString().Length == 1 ? $"0{date.Month}" : date.Month.ToString();
        ValCurs res = deserializerXML.deserialize(url + $"?date_req={day}/{month}/{date.Year}");
        return res;
    }

    /// <summary>
    /// Returns currency information for certain day
    /// </summary>
    /// <param name="date">certain day</param>
    /// <returns>valCurs</returns>
    public ValCurs find(DateTime date)
    {
        return deserialize(date);
    }
}