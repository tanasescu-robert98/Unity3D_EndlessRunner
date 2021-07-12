using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SloMoBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxSloMo(int slomo_val)
    {
        slider.maxValue = slomo_val;
        slider.value = slomo_val;
    }

    public void SetSloMo(int slomo_val)
    {
        slider.value = slomo_val;
    }
}
