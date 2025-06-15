using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum LightBulbType
{
    BASIC,
    DIMMABLE,
    COLOR_CHANGING
}

public class LightBulbController : MonoBehaviour
{
    [SerializeField]
    private LightBulbType _type;

    [SerializeField]
    private Image _bulbImage;

    [SerializeField]
    private TextMeshProUGUI _stateText;

    [SerializeField]
    private Toggle _powerToggle;

    [SerializeField]
    private Slider _powerSlider;

    [SerializeField]
    private Button _redButton;

    [SerializeField]
    private Button _greenButton;

    [SerializeField]
    private Button _blueButton;

    [SerializeField]
    private Button _whiteButton;

    private LightBulb _bulb = null;

    void Start()
    {
        switch (_type)
        {
            case LightBulbType.BASIC:
                _bulb = new LightBulb();
                break;
            case LightBulbType.DIMMABLE:
                _bulb = new DimmableLightBulb();
                EnableDimming(_bulb as DimmableLightBulb);
                break;
            case LightBulbType.COLOR_CHANGING:
                _bulb = new ColorChangingDimmableLightBulb();
                EnableColorChanging(_bulb as ColorChangingDimmableLightBulb);
                break;
        }

        _powerToggle.onValueChanged.AddListener((isOn) => { _bulb.SetPower(isOn); });
    }

    void Update()
    {
        _stateText.text = _bulb.DescribeState().Replace(",", "\n");
        _powerToggle.isOn = _bulb.IsOn;

        if (_bulb is ColorChangingDimmableLightBulb ccBulb)
        {
            SetPowerLevel(ccBulb.IsOn, ccBulb.PowerPercent, ccBulb.Color);
        }
        else if (_bulb is DimmableLightBulb dBulb)
        {
            SetPowerLevel(dBulb.IsOn, dBulb.PowerPercent);
        }
        else
        {
            SetPowerLevel(_bulb.IsOn);
        }
    }

    private void EnableDimming(DimmableLightBulb bulb)
    {
        _powerSlider.gameObject.SetActive(true);
        _powerSlider.onValueChanged.AddListener((level) => { bulb.SetPower((int)(level)); });
    }

    private void EnableColorChanging(ColorChangingDimmableLightBulb bulb)
    {
        EnableDimming(bulb);
        EnableColorButton(bulb, _redButton, LightColor.RED);
        EnableColorButton(bulb, _greenButton, LightColor.GREEN);
        EnableColorButton(bulb, _blueButton, LightColor.BLUE);
        EnableColorButton(bulb, _whiteButton, LightColor.WHITE);
    }

    private static void EnableColorButton(ColorChangingDimmableLightBulb bulb, Button button, LightColor color)
    {
        button.gameObject.SetActive(true);
        button.onClick.AddListener(() => { bulb.Color = color; });
    }

    private void SetPowerLevel(bool isOn)
    {
        SetPowerLevel(isOn, 100);
    }

    private void SetPowerLevel(bool isOn, int percentPower, LightColor newColor = LightColor.WHITE)
    {
        Color updatedColor = _bulbImage.color;

        updatedColor.a = isOn ? (percentPower / 100f) * 0.9f + 0.1f : 0.1f;
 
        // When on, the colors are selected in the switch below.
        // When off, the color should be white.
        updatedColor.r = isOn ? 0 : 1;
        updatedColor.g = isOn ? 0 : 1;
        updatedColor.b = isOn ? 0 : 1;

        switch (newColor)
        {
            case LightColor.WHITE:
                updatedColor.r = 1;
                updatedColor.g = 1;
                updatedColor.b = 1;
                break;
            case LightColor.RED:
                updatedColor.r = 1;
                break;
            case LightColor.GREEN:
                updatedColor.g = 1;
                break;
            case LightColor.BLUE:
                updatedColor.b = 1;
                break;
        }

        _bulbImage.color = updatedColor;
    }
}
