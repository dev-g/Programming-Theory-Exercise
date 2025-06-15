using UnityEngine;

// INHERITANCE

public class DimmableLightBulb : LightBulb
{
    // ENCAPSULATION

    public int PowerPercent => _powerPercent;

    private int _powerPercent = 0;

    // ENCAPSULATION
    // ABSTRACTION
    public void SetPower(int powerPercent)
    {
        if (powerPercent < 0 || powerPercent > 100)
        {
            Debug.LogError($"Invalid power: {powerPercent}");
            return;
        }

        _powerPercent = powerPercent;

        SetPower(_powerPercent > 0);
    }

    // POLYMORPHISM

    public override string DescribeState()
    {
        return $"{base.DescribeState()}, power: {_powerPercent}%";
    }
}
