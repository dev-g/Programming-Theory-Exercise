using NUnit.Framework;
using System;
using System.Collections.Generic;

public class LightBulbTests
{
    [Test]
    public void Construction_PowerIsOff()
    {
        var bulb = new LightBulb();

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual("on: False", bulb.DescribeState());
    }

    [Test]
    public void SetPower_WhenOff_TurnsOn()
    {
        var bulb = new LightBulb();

        Assert.AreEqual(false, bulb.IsOn);

        bulb.SetPower(true);

        Assert.AreEqual(true, bulb.IsOn);
        Assert.AreEqual("on: True", bulb.DescribeState());
    }

    [Test]
    public void SetPower_WhenOn_TurnsOff()
    {
        var bulb = new LightBulb();
        bulb.SetPower(true);

        Assert.AreEqual(true, bulb.IsOn);

        bulb.SetPower(false);

        Assert.AreEqual(false, bulb.IsOn);
    }

    [Test]
    public void ToggleOnOff_WhenOff_TurnsOn()
    {
        var bulb = new LightBulb();

        Assert.AreEqual(false, bulb.IsOn);

        bulb.ToggleOnOff();

        Assert.AreEqual(true, bulb.IsOn);
    }

    [Test]
    public void ToggleOnOff_WhenOn_TurnsOff()
    {
        var bulb = new LightBulb();
        bulb.SetPower(true);
        Assert.AreEqual(true, bulb.IsOn);

        bulb.ToggleOnOff();

        Assert.AreEqual(false, bulb.IsOn);
    }

}
