using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DSR_Summer_Practice.Shared.Entieties
{
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

	//   [XmlRoot(ElementName = "ValCurs")]
	//public class ValCurs
	//{
	//       [XmlElement(ElementName = "Valute")]
	//       public List<Valute> Valute { get; set; }

	//       //[XmlArray("Valute")]
	//       //[XmlArrayItem("Valute")]
	//       ////[XmlElement(ElementName = "Valute")]
	//       //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
	//       //public Valute[] ValuteArray
	//       //{
	//       //    get
	//       //    {
	//       //        if (Valute == null)
	//       //            return null;
	//       //        return Valute.ToArray();
	//       //    }
	//       //    set
	//       //    {
	//       //        Valute = value;
	//       //    }
	//       //}

	//       [XmlAttribute(AttributeName = "Date")]
	//	public string Date { get; set; }

	//	[XmlAttribute(AttributeName = "name")]
	//	public string Name { get; set; }

	//	[XmlText]
	//	public string Text { get; set; }
	//}
}
