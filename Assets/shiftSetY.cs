using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftSetY : MonoBehaviour
{
    
    public void setShiftY()
    {
        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("shiftyslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
