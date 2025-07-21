using System;

namespace CSharpFantaMentos13.View2;

public sealed class Citrus(string name, string color, int vitamin_c) : Fruit(name, color)
{
    #region Instance
    public int VitaminC
    {
        get => field;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    } = vitamin_c;
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
    public override string ToString()
    {
        return $"{base.ToString()}; {nameof(VitaminC)}: {VitaminC}";
    }
    #endregion
}