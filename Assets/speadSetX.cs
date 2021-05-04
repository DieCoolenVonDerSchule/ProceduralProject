using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speadSetX : MonoBehaviour
{
    public void setSpreadX()
    {
        GameObject.FindGameObjectWithTag("spreadx").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("spreadxslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
