using System.Xml.Serialization;

[XmlRoot("Result")]
public class ResultXML
{
    public string Ori { get; set; }
    public string New { get; set; }
}

[XmlRoot("Result")]
public class ErrorXML
{
    public string errorMSG { get; set; }
}
