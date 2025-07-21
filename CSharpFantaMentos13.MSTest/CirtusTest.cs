using System.Text;
using CSharpFantaMentos13.View1;

namespace CSharpFantaMentos13.MSTest;

[TestClass]
public sealed class CitrusTest
{
    [TestMethod] public void ConstructorTest()
    {
        Citrus citrus = new("Lemon", "Yellow", 5);
        Assert.AreEqual("Lemon", citrus.Name, $"Constructor initialize {nameof(Citrus)}.{nameof(Citrus.Name)} incorrectly");
        Assert.AreEqual("Yellow", citrus.Color, $"Constructor initialize {nameof(Citrus)}.{nameof(Citrus.Color)} incorrectly");
        Assert.AreEqual(5, citrus.VitaminC, $"Constructor initialize {nameof(Citrus)}.{nameof(Citrus.VitaminC)} incorrectly");
        Assert.ThrowsException<ArgumentOutOfRangeException>(delegate
        {
            Citrus citrus = new("", "", -5);
        }, $"Constructor must throw an '{nameof(ArgumentOutOfRangeException)}' when 'vitamin_c' parameter is negative");
    }
    [TestMethod] public void PropertiesTest()
    {
        Citrus citrus = new("", "", 0)
        {
            Name = "Lemon",
            Color = "Yellow",
            VitaminC = 5,
        };
        Assert.AreEqual("Lemon", citrus.Name, $"{nameof(Citrus)}.{nameof(Citrus.Name)} get/set incorrect");
        Assert.AreEqual("Yellow", citrus.Color, $"{nameof(Citrus)}.{nameof(Citrus.Color)} get/set incorrect");
        Assert.AreEqual(5, citrus.VitaminC, $"{nameof(Citrus)}.{nameof(Citrus.VitaminC)} get/set incorrect");
        Assert.ThrowsException<ArgumentOutOfRangeException>(delegate
        {
            citrus.VitaminC = -5;
        }, $"{nameof(Citrus)}.{nameof(Citrus.VitaminC)} set must throw an '{nameof(ArgumentOutOfRangeException)}' when 'value' parameter is negative");
    }
    [TestMethod] public void InputMethodTest()
    {
        Console.SetIn(new StringReader($"Lemon{Environment.NewLine}Yellow{Environment.NewLine}5{Environment.NewLine}"));
        Citrus citrus = new("", "", 0);
        citrus.Input();
        Assert.AreEqual("Lemon", citrus.Name, $"void {nameof(Citrus)}.{nameof(Citrus.Input)}() initialize {nameof(Citrus)}.{nameof(Citrus.Name)} incorrectly");
        Assert.AreEqual("Yellow", citrus.Color, $"void {nameof(Citrus)}.{nameof(Citrus.Input)}() initialize {nameof(Citrus)}.{nameof(Citrus.Color)} incorrectly");
        Assert.AreEqual(5, citrus.VitaminC, $"void {nameof(Citrus)}.{nameof(Citrus.Input)}() initialize {nameof(Citrus)}.{nameof(Citrus.VitaminC)} incorrectly");
        Assert.ThrowsException<ArgumentOutOfRangeException>(delegate
        {
            Console.SetIn(new StringReader($"Lemon{Environment.NewLine}Yellow{Environment.NewLine}-5{Environment.NewLine}"));
            Citrus citrus = new("", "", 0);
            citrus.Input();
        }, $"{nameof(Citrus)}.{nameof(Citrus.VitaminC)} set must throw an '{nameof(ArgumentOutOfRangeException)}' when 'value' parameter is negative");
    }
    [TestMethod] public void OutputMethodTest()
    {
        StringBuilder builder = new();
        Console.SetOut(new StringWriter(builder));
        Citrus citrus = new("Lemon", "Yellow", 5);
        citrus.Output();
        Assert.AreEqual($"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}{Environment.NewLine}", builder.ToString(), $"void {nameof(Citrus)}.{nameof(Citrus.Output)}() works incorrectly");
    }
    [TestMethod] public void ToStringMethodTest()
    {
        Citrus citrus = new("Lemon", "Yellow", 5);
        Assert.AreEqual($"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}", citrus.ToString(), "string ToString() returns invalid value");

        Fruit fruit = citrus;
        Assert.AreEqual($"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}", fruit.ToString(), "string ToString() must override Fruit.ToString()");
    }
}