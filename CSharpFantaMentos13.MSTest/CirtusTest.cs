using System.Text;
using CSharpFantaMentos13.View1;

namespace CSharpFantaMentos13.MSTest;

[TestClass]
public sealed class CitrusTest
{
    [TestMethod] public void ConstructorTest()
    {
        Citrus citrus = new("Lemon", "Yellow", 5);
        Assert.AreEqual("Lemon", citrus.Name, $"Constructor initialize '{nameof(Citrus.Name)}' incorrectly");
        Assert.AreEqual("Yellow", citrus.Color, $"Constructor initialize '{nameof(Citrus.Color)}' incorrectly");
        Assert.AreEqual(5, citrus.VitaminC, $"Constructor initialize '{nameof(Citrus.VitaminC)}' incorrectly");
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
        Assert.AreEqual("Lemon", citrus.Name, $"'{nameof(Citrus.Name)}' get/set incorrect");
        Assert.AreEqual("Yellow", citrus.Color, $"'{nameof(Citrus.Color)}' get/set incorrect");
        Assert.AreEqual(5, citrus.VitaminC, $"'{nameof(Citrus.VitaminC)}' get/set incorrect");
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            action: delegate
            {
                citrus.VitaminC = -5;
            }, 
            message: $"'{nameof(Citrus.VitaminC)}' set must throw an '{nameof(ArgumentOutOfRangeException)}' when 'value' parameter is negative"
        );
    }
    [TestMethod] public void InputMethodTest()
    {
        Console.SetIn(new StringReader($"Lemon{Environment.NewLine}Yellow{Environment.NewLine}5{Environment.NewLine}"));
        Citrus citrus = new("", "", 0);
        citrus.Input();
        Assert.AreEqual("Lemon", citrus.Name, $"'instance void {nameof(Citrus.Input)}()' initialize '{nameof(Citrus.Name)}' incorrectly");
        Assert.AreEqual("Yellow", citrus.Color, $"'instance void {nameof(Citrus.Input)}()' initialize '{nameof(Citrus.Color)}' incorrectly");
        Assert.AreEqual(5, citrus.VitaminC, $"'instance void {nameof(Citrus.Input)}()' initialize '{nameof(Citrus.VitaminC)}' incorrectly");
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            action: delegate
            {
                Console.SetIn(new StringReader($"Lemon{Environment.NewLine}Yellow{Environment.NewLine}-5{Environment.NewLine}"));
                Citrus citrus = new("", "", 0);
                citrus.Input();
            }, 
            message: $"'{nameof(Citrus.VitaminC)}' set must throw an '{nameof(ArgumentOutOfRangeException)}' when 'value' parameter is negative"
        );
    }
    [TestMethod] public void OutputMethodTest()
    {
        StringBuilder builder = new();
        Console.SetOut(new StringWriter(builder));
        Citrus citrus = new("Lemon", "Yellow", 5);
        citrus.Output();
        Assert.AreEqual(
            expected: $"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}{Environment.NewLine}",
            actual: builder.ToString(),
            message: $"'void {nameof(Citrus.Output)}()' works incorrectly"
        );
    }
    [TestMethod] public void ToStringMethodTest()
    {
        Citrus citrus = new("Lemon", "Yellow", 5);
        Assert.AreEqual(
            expected: $"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}", 
            actual: citrus.ToString(),
            message: "'instance string ToString()' returns invalid value"
        );

        Fruit fruit = citrus;
        Assert.AreEqual(
            expected: $"{nameof(Fruit.Name)}: {citrus.Name}; {nameof(Fruit.Color)}: {citrus.Color}; {nameof(Citrus.VitaminC)}: {citrus.VitaminC}", 
            actual: fruit.ToString(),
            message: "'instance string ToString()' must override 'Fruit.ToString()'"
        );
    }
}