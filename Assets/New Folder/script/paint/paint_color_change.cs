using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paint_color_change : MonoBehaviour
{
    public Image image;
    public Slider[] sliders;

    public bool is_touch;

    private void Update()
    {
        if (!is_touch) { return; }
        image.material.color = new Color(sliders[0].value, sliders[1].value, sliders[2].value);
    }
    public void is_touch_bool(bool value)
    {
        is_touch = value;
    }
}
