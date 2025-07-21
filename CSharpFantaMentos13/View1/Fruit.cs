using System;
using System.Globalization;

namespace CSharpFantaMentos13.View1;

public class Fruit
{
    #region Static
    static internal T GetValueFromConsole<T>(string message) where T : IParsable<T>
    {
        T? value;
        Console.Write($"{message}({typeof(T).FullName})>>> ");
        while(T.TryParse(Console.ReadLine() ?? "", CultureInfo.InvariantCulture, out value) is false)
        {
            Console.Write("Can`t parse input. Try again: ");
            Console.Write($"{message}({typeof(T).FullName})>>> ");
        }
        return value;
    }
    #endregion

    #region Instance
    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }

    private string color;
    public string Color
    {
        get => color;
        set
        {
            color = value;
        }
    }

    public Fruit(string name, string color)
    {
        this.name = name;
        this.color = color;
    }

    public virtual void Input()
    {
        Name = GetValueFromConsole<string>($"{nameof(Fruit)}.{nameof(Name)}");
        Color = GetValueFromConsole<string>($"{nameof(Fruit)}.{nameof(Color)}");
    }
    public virtual void Output()
    {
        Console.WriteLine(this.ToString());
    }
    #endregion

    #region Object
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}; {nameof(Color)}: {Color}";
    }
    #endregion
}