using DSR_Summer_Practice.Shared.Entieties;
using DSR_Summer_Practice.Shared.Interfaces;

namespace DSR_Summer_Practice.Shared.Repositories
{
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
            return deserializeOnURL(start, end);
        }

        private IEnumerable<ValCurs> deserializeOnURL(DateTime start, DateTime end)
        {
            List<ValCurs> valCurs = new List<ValCurs>();
            for (var i = start; i <= end; i = i.AddDays(1))
            {
                string day = i.Day.ToString().Length == 1 ? $"0{i.Day}" : i.Day.ToString();
                string month = i.Month.ToString().Length == 1 ? $"0{i.Month}" : i.Month.ToString();
                var temp = deserializerXML.deserialize(url + $"?date_req={day}/{month}/{i.Year}");
                temp.Date = i.ToString();
                //valCurs.Add(deserializerXML.deserialize(url + $"?date_req={day}/{month}/{i.Year}"));
                valCurs.Add(temp);
            }
            return valCurs;
        }

        /// <summary>
        /// Returns currency information for today
        /// </summary>
        /// <returns>ValCurs</returns>
        public ValCurs get()
        {
            return deserializerXML.deserialize(url);
        }
    }
}
