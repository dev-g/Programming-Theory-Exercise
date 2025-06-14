public class LightBulb
{
    public bool IsOn => _isOn;

    private bool _isOn = false;
    

    public virtual void SetPower(bool on)
    {
        _isOn = on;
    }

    public void ToggleOnOff()
    {
        SetPower(!_isOn);
    }

    public virtual string DescribeState()
    {
        return $"on: {_isOn}";
    }
}
