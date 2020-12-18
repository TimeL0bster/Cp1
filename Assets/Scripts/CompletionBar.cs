using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionBar : MonoBehaviour
{
    private Slider completionSlider;

    private void Start()
    {
        completionSlider = GetComponent<Slider>();

        completionSlider.value = 0;
    }

    public void setPoint(float point)
    {
        completionSlider.value = point;
    }

}
