using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipShopColor : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    List<Image> frontSubImages = null;

    [SerializeField]
    List<Image> backSubImages = null;

    [SerializeField]
    ShipColorSlider redSlider = null;

    [SerializeField]
    ShipColorSlider greenSlider = null;

    [SerializeField]
    ShipColorSlider blueSlider = null;

    [SerializeField]
    ShipColorToggle backSelector = null;

    [SerializeField]
    ShipColorToggle frontSelector = null;


    [SerializeField]
    GameEvent colorsChanged = null;

    bool frontSelected = false;

    bool initializing = false;

    public bool FrontSelected
    {
        get
        {
            return frontSelected;
        }
        set
        {
            if (frontSelected != value || initializing)
            {
                frontSelected = value;
                DisableEvents();
                UpdateColorSliders();
                UpdateSelectorStates();
                EnableEvents();
            }
        }
    }

    Color frontColor;

    Color backColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        initializing = true;
        frontColor = player.Data.FrontColor;
        backColor = player.Data.BackColor;
        SetFrontColor(frontColor);
        SetBackColor(backColor);

        DisableEvents();
        FrontSelected = true;
        initializing = false;
    }

    public void SetFrontColor(Color c)
    {
        foreach (var image in frontSubImages)
        {
            image.color = c;
        }
    }

    public void SetPlayerColors()
    {
        player.Data.BackColor = backColor;
        player.Data.FrontColor = frontColor;
        colorsChanged.Invoke();
    }

    public void SetBackColor(Color c)
    {
        foreach (var image in backSubImages)
        {
            image.color = c;
        }
    }

    void UpdateSelectorStates()
    {
        frontSelector.Toggle.isOn = frontSelected;
        backSelector.Toggle.isOn = !frontSelected;
    }

    public void UpdateImages()
    {
        if (frontSelected)
        {
            frontColor.r = redSlider.Value;
            frontColor.g = greenSlider.Value;
            frontColor.b = blueSlider.Value;
            SetFrontColor(frontColor);
        }
        else
        {
            backColor.r = redSlider.Value;
            backColor.g = greenSlider.Value;
            backColor.b = blueSlider.Value;
            SetBackColor(backColor);
        }
    }

    void DisableEvents()
    {
        redSlider.SendEvent = false;
        greenSlider.SendEvent = false;
        blueSlider.SendEvent = false;
        frontSelector.SendEvent = false;
        backSelector.SendEvent = false;
    }

    void EnableEvents()
    {
        redSlider.SendEvent = true;
        greenSlider.SendEvent = true;
        blueSlider.SendEvent = true;
        frontSelector.SendEvent = true;
        backSelector.SendEvent = true;
    }

    void UpdateColorSliders()
    {
        var color = frontSelected ? frontColor : backColor;

        redSlider.Value = color.r;
        greenSlider.Value = color.g;
        blueSlider.Value = color.b;
    }
}
