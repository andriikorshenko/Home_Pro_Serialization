using System.Xml.Serialization;

string previousTaskXmlFilePath = @"C:\Users\Admin\Desktop\Pro\Home_008\Task_002\bin\Debug\net6.0\MyXML.xml";

static T? DesirializeMyXmlFile<T>(string path)
{
    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

    using (Stream fileStream = new FileStream(path, FileMode.Open))
    {
        return (T?)xmlFormat.Deserialize(fileStream);
    }
}

Car myCar = new Car();

Car? myCarDes = DesirializeMyXmlFile<Car>(previousTaskXmlFilePath);
Console.WriteLine(myCarDes?.ToString());