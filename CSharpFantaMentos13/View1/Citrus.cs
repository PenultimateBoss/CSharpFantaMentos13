using System;

namespace CSharpFantaMentos13.View1;

public sealed class Citrus : Fruit
{
    #region Instance
    private int vitamin_c;
    public int VitaminC
    {
        get => vitamin_c;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));
            vitamin_c = value;
        }
    }

    public Citrus(string name, string color, int vitamin_c) : base(name, color)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(vitamin_c, nameof(vitamin_c));
        this.vitamin_c = vitamin_c;
    }
    #endregion

    #region Fruit
    public override void Input()
    {
        base.Input();
        VitaminC = Fruit.GetValueFromConsole<int>($"{nameof(Fruit)}.{nameof(VitaminC)}");
    }
    public override void Output()
    {
        Console.WriteLine(this.ToString());
    }
    #endregion

    #region Object
    public override string ToString()
    {
        return $"{base.ToString()}; {nameof(VitaminC)}: {VitaminC}";
    }
    #endregion
}