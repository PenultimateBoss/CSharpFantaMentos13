using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using CSharpFantaMentos13.View1;
using System.Collections.Generic;

JsonSerializerOptions json_options = new()
{
    WriteIndented = true,
};
List<Fruit> list = new()
{
    new Fruit("Cherry", "Red"),
    new Fruit("Banana", "Yellow"),
    new Citrus("Orange", "Orange", 5),
};

Console.WriteLine("Apple:");
Fruit apple = new("", "");
apple.Input();
list.Add(apple);
Console.WriteLine();

Console.WriteLine("Lemon:");
Citrus lemon = new("", "", 0);
while(true)
{
    try
    {
        lemon.Input();
        list.Add(lemon);
        break;
    }
    catch(Exception exception)
    {
        Console.WriteLine(exception.Message);
        Console.WriteLine("Try again");
    }
}
Console.WriteLine();

Console.WriteLine("Yellow fruits:");
foreach(Fruit fruit in list.Where(static fruit => fruit.Color is "Yellow"))
{
    fruit.Output();
}

list.Sort();
File.WriteAllText("FruitList.json", JsonSerializer.Serialize(list, json_options));

try
{
    list = JsonSerializer.Deserialize<List<Fruit>>(File.ReadAllText("FruitList.json"), json_options) ?? throw new Exception("Can`t deserialize 'FruitList.json'");
    Console.WriteLine(JsonSerializer.Serialize(list, json_options));
}
catch(Exception exception)
{
    Console.WriteLine(exception.Message);
}