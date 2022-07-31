using System.Xml.Serialization;

string fileName = @"MyXML.xml";

static void SaveMyObjToXmlFormat<T>(T obj, string fileName)
{
    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

    using (FileStream fileStram = new FileStream(fileName, 
        FileMode.Create, 
        FileAccess.Write, 
        FileShare.None))
    {
        xmlFormat.Serialize(fileStram, obj);
    }
}

static T? ReadMyObjFromXmlFile<T>(string fileName)
{
    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

    using (FileStream fileSrteam = new FileStream(fileName, FileMode.Open))
    {
        return (T?)xmlFormat.Deserialize(fileSrteam);
    }
}

Car car = new Car("Audi", 2022, 42_000);

SaveMyObjToXmlFormat(car, fileName);

Car? carDes = ReadMyObjFromXmlFile<Car>(fileName);
Console.WriteLine(carDes?.ToString());

[Serializable, XmlRoot(Namespace = "https://audi.ua")]
public class Car
{
    [XmlAttribute("MyBrand")]
    public string? Brand;

    [XmlAttribute("This_Year")]
    public uint Year;

    [XmlAttribute("Super_Price")]
    public uint Price;

    public Car(string brand, uint year, uint price)
    {
        Brand = brand;
        Year = year;
        Price = price;
    }

    public Car() { }

    public override string ToString()
        => $"{Brand}, {Year}, {Price}";
}