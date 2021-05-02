using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleSetX : MonoBehaviour
{
   

    public void setScaleX()
    {

        GameObject.FindGameObjectWithTag("scalex").GetComponent<UnityEngine.UI.InputField>().text = 
            GameObject.FindGameObjectWithTag("scalexslider").GetComponent< UnityEngine.UI.Slider>().value.ToString();


    }
}
