using NUnit.Framework;
using System;
using System.Collections.Generic;

public class ColorChangingDimmableLightBulbTests
{
    [Test]
    public void Construction_PowerIsOffPercentIsZeroColorIsWhite()
    {
        var bulb = new ColorChangingDimmableLightBulb();

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(0, bulb.PowerPercent);
        Assert.AreEqual(LightColor.WHITE, bulb.Color);
        Assert.AreEqual(
            "on: False, power: 0%, color: WHITE", 
            bulb.DescribeState());
    }

    [Test]
    public void Color_ColorIsWhite_SettingColorWorks()
    {
        var bulb = new ColorChangingDimmableLightBulb();
        Assert.AreEqual(LightColor.WHITE, bulb.Color);

        bulb.Color = LightColor.RED;

        Assert.AreEqual(LightColor.RED, bulb.Color);

        Assert.AreEqual(
            "on: False, power: 0%, color: RED",
            bulb.DescribeState());

    }
}
