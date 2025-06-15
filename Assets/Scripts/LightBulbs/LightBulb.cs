public class LightBulb
{
    // ENCAPSULATION

    public bool IsOn => _isOn;

    private bool _isOn = false;

    // ENCAPSULATION

    public virtual void SetPower(bool on)
    {
        _isOn = on;
    }

    public void ToggleOnOff()
    {
        SetPower(!_isOn);
    }

    // POLYMORPHISM

    public virtual string DescribeState()
    {
        return $"on: {_isOn}";
    }
}
