using NUnit.Framework;
using System;
using System.Collections.Generic;

public class DimmableLightBulbTests
{
    [Test]
    public void Construction_PowerIsOffPercentIsZero()
    {
        var bulb = new DimmableLightBulb();

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(0, bulb.PowerPercent);
        Assert.AreEqual("on: False, power: 0%", bulb.DescribeState());
    }

    
    [Test]
    public void SetPower_WhenOff_SetPercentAndTurnsOn()
    {
        var bulb = new DimmableLightBulb();

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(0, bulb.PowerPercent);

        bulb.SetPower(5);

        Assert.AreEqual(true, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);
        Assert.AreEqual("on: True, power: 5%", bulb.DescribeState());

    }

    [Test]
    public void SetPower_WhenOn_SetPercentZeroTurnsOff()
    {
        var bulb = new DimmableLightBulb();
        bulb.SetPower(5);

        Assert.AreEqual(true, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);

        bulb.SetPower(0);

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(0, bulb.PowerPercent);
    }

    [Test]
    public void SetPower_WhenOn_SetBooleanFalseDoesntChangePercentage()
    {
        var bulb = new DimmableLightBulb();
        bulb.SetPower(5);

        Assert.AreEqual(true, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);

        bulb.SetPower(false);

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);
    }

    [Test]
    public void SetPower_WhenOff_SetBooleanFalseDoesntChangePercentage()
    {
        var bulb = new DimmableLightBulb();
        bulb.SetPower(5);
        bulb.SetPower(false);

        Assert.AreEqual(false, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);

        bulb.SetPower(true);

        Assert.AreEqual(true, bulb.IsOn);
        Assert.AreEqual(5, bulb.PowerPercent);
    }
}
