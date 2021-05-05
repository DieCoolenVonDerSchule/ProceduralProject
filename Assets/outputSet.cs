using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputSet : MonoBehaviour
{
    public void setOutput()
    {
        GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("outputslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }
}
