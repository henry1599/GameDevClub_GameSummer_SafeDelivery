using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuantity : MonoBehaviour
{
    public GameObject quantity;
    public Slider slider;
    private void Update()
    {
        SharedUI.LEVEL = (int)slider.value;
        quantity.GetComponent<TMPro.TextMeshProUGUI>().text = slider.value.ToString();
       
    }
}
