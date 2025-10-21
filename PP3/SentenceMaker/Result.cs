using System.Xml.Serialization;

[XmlRoot("Result")]
public class ResultXML
{
    public string ori { get; set; }
    public string newSen { get; set; }
}

[XmlRoot("Result")]
public class ErrorXML
{
    public string errorMSG { get; set; }
}
