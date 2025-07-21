using System.Text;
using CSharpFantaMentos13.View1;

namespace CSharpFantaMentos13.MSTest;

[TestClass]
public sealed class FruitTest
{
    [TestMethod] public void ConstructorTest()
    {
        Fruit fruit = new("Apple", "Red");
        Assert.AreEqual("Apple", fruit.Name, $"Constructor initialize '{nameof(Fruit.Name)}' incorrectly");
        Assert.AreEqual("Red", fruit.Color, $"Constructor initialize '{nameof(Fruit.Color)}' incorrectly");
    }
    [TestMethod] public void PropertiesTest()
    {
        Fruit fruit = new("", "")
        {
            Name = "Apple",
            Color = "Red",
        };
        Assert.AreEqual("Apple", fruit.Name, $"'{nameof(Fruit.Name)}' get/set incorrect");
        Assert.AreEqual("Red", fruit.Color, $"'{nameof(Fruit.Color)}' get/set incorrect");
    }
    [TestMethod] public void InputMethodTest()
    {
        Console.SetIn(new StringReader($"Apple{Environment.NewLine}Red{Environment.NewLine}"));
        Fruit fruit = new("", "");
        fruit.Input();
        Assert.AreEqual("Apple", fruit.Name, $"'instance void {nameof(Fruit.Input)}()' initialize '{nameof(Fruit.Name)}' incorrectly");
        Assert.AreEqual("Red", fruit.Color, $"'instance void {nameof(Fruit.Input)}()' initialize '{nameof(Fruit.Color)}' incorrectly");
    }
    [TestMethod] public void OutputMethodTest()
    {
        StringBuilder builder = new();
        Console.SetOut(new StringWriter(builder));
        Fruit fruit = new("Apple", "Red");
        fruit.Output();
        Assert.AreEqual(
            expected: $"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}{Environment.NewLine}", 
            actual: builder.ToString(), 
            message: $"'instance void {nameof(Fruit.Output)}()' works incorrectly"
        );
    }
    [TestMethod] public void ToStringMethodTest()
    {
        Fruit fruit = new("Apple", "Red");
        Assert.AreEqual($"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}", fruit.ToString(), "'instance string ToString()' returns invalid value");

        object obj = fruit;
        Assert.AreEqual(
            expected: $"{nameof(Fruit.Name)}: {fruit.Name}; {nameof(Fruit.Color)}: {fruit.Color}",
            actual: obj.ToString(), 
            message: "'instance string ToString()' must override 'object.ToString()'"
        );
    }
    [TestMethod] public void CompareMethodTest()
    {
        Fruit fruit1 = new("Apple", "Red");
        Fruit fruit2 = new("Banana", "Yellow");
        Fruit fruit3 = new("Apple", "Green");

        Assert.AreEqual(-1, fruit1.CompareTo(fruit2), $"'instance int CompareTo({nameof(Fruit)} other)' must compare objects by '{nameof(Fruit.Name)}' property");
        Assert.AreEqual(1, fruit2.CompareTo(fruit1), $"'instance int CompareTo({nameof(Fruit)} other)' must compare objects by '{nameof(Fruit.Name)}' property");
        Assert.AreEqual(0, fruit1.CompareTo(fruit3), $"'instance int CompareTo({nameof(Fruit)} other)' must compare objects by '{nameof(Fruit.Name)}' property");
    }
}