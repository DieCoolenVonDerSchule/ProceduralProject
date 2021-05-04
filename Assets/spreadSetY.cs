using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreadSetY : MonoBehaviour
{
    public void setSpreadY()
    {
        GameObject.FindGameObjectWithTag("spready").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("spreadyslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
