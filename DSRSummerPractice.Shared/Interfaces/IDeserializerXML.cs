namespace DSRSummerPractice.Shared.Interfaces;

public interface IDeserializerXML<T> where T : class
{
    T deserialize(string url);
}
