namespace DSRSummerPractice.Shared.Entieties;

using System.Xml.Serialization;

[XmlRoot(ElementName = "ValCurs")]
public class ValCurs
{

	[XmlElement(ElementName = "Valute")]
	public List<Valute> Valute { get; set; }

	[XmlAttribute(AttributeName = "Date")]
	public string Date { get; set; }

	[XmlAttribute(AttributeName = "name")]
	public string Name { get; set; }

	[XmlText]
	public string Text { get; set; }
}