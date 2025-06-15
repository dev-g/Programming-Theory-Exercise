
// INHERITANCE

public class ColorChangingDimmableLightBulb : DimmableLightBulb
{
    public LightColor Color = LightColor.WHITE;

    // ENCAPSULATION

    public void SetPower(int powerPercent, LightColor color)
    {
        Color = color;
        base.SetPower(powerPercent);
    }

    // POLYMORPHISM

    public override string DescribeState()
    {
        return $"{base.DescribeState()}, color: {Color}";
    }
}
