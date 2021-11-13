using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{


    Vector3 localScale; //Health-bar
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {        
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    public void decreaseHealth()
    {
        slider.value = slider.value - 1;
        if(slider.value <= 0)
        {
            slider.value = 0;
        }
    }

    public void increaseHealth()
    {
        slider.value = slider.value + 1;

        if (slider.value >= 0)
        {
            slider.value = slider.maxValue;
        }
    }

    public int getHealth()
    {
        return (int) slider.value;
    }
}
