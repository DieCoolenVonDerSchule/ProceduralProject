using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftSetX : MonoBehaviour
{
    public void setShiftX()
    {

        GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("shiftxslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
