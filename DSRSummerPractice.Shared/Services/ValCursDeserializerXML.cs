namespace DSRSummerPractice.Shared.Services;

using DSRSummerPractice.Shared.Entieties;
using DSRSummerPractice.Shared.Interfaces;
using System.Net;
using System.Text;
using System.Xml.Serialization;


public class ValCursDeserializerXML : IDeserializerXML<ValCurs>
{
    /// <summary>
    /// Downloads an xml file by URL and deserializes it
    /// </summary>
    /// <param name="url">file url</param>
    /// <returns>ValCurs</returns>
    public ValCurs deserialize(string url)
    {
        byte[] bytes;
        using (var webClient = new WebClient())
        {
            bytes = webClient.DownloadData(url);
        }
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding encoding1251 = Encoding.GetEncoding("windows-1251");
        var convertedBytes = Encoding.Convert(encoding1251, Encoding.UTF8, bytes);
        string xml = Encoding.UTF8.GetString(convertedBytes);
        XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
        ValCurs res;
        using (StringReader reader = new StringReader(xml))
        {
            res = (ValCurs)serializer.Deserialize(reader);
        }
        return res;
    }
}