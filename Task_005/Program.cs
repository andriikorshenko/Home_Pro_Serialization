using System.Text.Json;

string fileName = @"MyJson.json";

var options = new JsonSerializerOptions
{
    WriteIndented = true,
};

static void SaveAsJsonFormat<T>(T obj, string fileName, JsonSerializerOptions options)
    => File.WriteAllText(fileName, JsonSerializer.Serialize(obj, options));

static T? ReadMyJsonFile<T>(string fileName)
    => JsonSerializer.Deserialize<T>(File.ReadAllText(fileName));

Car car = new Car("Toyota", 2022, 38_000);

SaveAsJsonFormat(car, fileName, options);

Car? carDes = ReadMyJsonFile<Car>(fileName);
Console.WriteLine(carDes?.ToString());

class Car
{
    private string? _brand;
    private uint _year;
    private uint _price;

    public string? Brand { get => _brand; }
    public uint Year { get => _year; }
    public uint Price { get => _price; }

    public Car(string brand, uint year, uint price)
    {
        _brand = brand;
        _year = year;
        _price = price;
    }

    public override string ToString()
        => $"{Brand}, {Year}, {Price}";
}

