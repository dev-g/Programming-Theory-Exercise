
public class ColorChangingDimmableLightBulb : DimmableLightBulb
{
    public LightColor Color = LightColor.WHITE;

    public void SetPower(int powerPercent, LightColor color)
    {
        Color = color;
        base.SetPower(powerPercent);
    }

    public override string DescribeState()
    {
        return $"{base.DescribeState()}, color: {Color}";
    }
}
