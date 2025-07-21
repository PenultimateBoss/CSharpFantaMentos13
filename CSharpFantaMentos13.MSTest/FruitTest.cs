using System.Text;
using CSharpFantaMentos13.View1;

namespace CSharpFantaMentos13.MSTest;

[TestClass]
public sealed class FruitTest
{
    [TestMethod] public void ConstructorTest()
    {
        Fruit fruit = new("Apple", "Red");
        Assert.AreEqual("Apple", fruit.Name, $"Constructor initialize {nameof(Fruit)}.{nameof(Fruit.Name)} incorrectly");
        Assert.AreEqual("Red", fruit.Color, $"Constructor initialize {nameof(Fruit)}.{nameof(Fruit.Color)} incorrectly");
    }
    [TestMethod] public void PropertiesTest()
    {
        Fruit fruit = new("", "")
        {
            Name = "Apple",
            Color = "Red",
        };
        Assert.AreEqual("Apple", fruit.Name, $"{nameof(Fruit)}.{nameof(Fruit.Name)} get/set incorrect");
        Assert.AreEqual("Red", fruit.Color, $"{nameof(Fruit)}.{nameof(Fruit.Color)} get/set incorrect");
    }
    [TestMethod] public void InputMethodTest()
    {
        Console.SetIn(new StringReader($"Apple{Environment.NewLine}Red{Environment.NewLine}"));
        Fruit fruit = new("", "");
        fruit.Input();
        Assert.AreEqual("Apple", fruit.Name, $"void {nameof(Fruit)}.{nameof(Fruit.Input)}() initialize {nameof(Fruit)}.{nameof(Fruit.Name)} incorrectly");
        Assert.AreEqual("Red", fruit.Color, $"void {nameof(Fruit)}.{nameof(Fruit.Input)}() initialize {nameof(Fruit)}.{nameof(Fruit.Color)} incorrectly");
    }
    [TestMethod] public void OutputMethodTest()
    {
        StringBuilder builder = new();
        Console.SetOut(new StringWriter(builder));
        Fruit fruit = new("Apple", "Red");
        fruit.Output();
        Assert.AreEqual($"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}{Environment.NewLine}", builder.ToString(), $"void {nameof(Fruit)}.{nameof(Fruit.Output)}() works incorrectly");
    }
    [TestMethod] public void ToStringMethodTest()
    {
        Fruit fruit = new("Apple", "Red");
        Assert.AreEqual($"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}", fruit.ToString(), "string ToString() returns invalid value");

        object obj = fruit;
        Assert.AreEqual($"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}", obj.ToString(), "string ToString() must override object.ToString()");
    }
    [TestMethod] public void CompareMethodTest()
    {
        Fruit fruit1 = new("Apple", "Red");
        Fruit fruit2 = new("Banana", "Yellow");
        Fruit fruit3 = new("Apple", "Green");

        Assert.AreEqual(-1, fruit1.CompareTo(fruit2), $"int CompareTo({nameof(Fruit)} other) must compare object by {nameof(Fruit.Name)} property");
        Assert.AreEqual(1, fruit2.CompareTo(fruit1), $"int CompareTo({nameof(Fruit)} other) must compare object by {nameof(Fruit.Name)} property");
        Assert.AreEqual(0, fruit1.CompareTo(fruit3), $"int CompareTo({nameof(Fruit)} other) must compare object by {nameof(Fruit.Name)} property");
    }
}