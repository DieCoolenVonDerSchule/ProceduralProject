using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleSetY : MonoBehaviour
{
    

    public void setScaleY()
    {

        GameObject.FindGameObjectWithTag("scaley").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("scaleyslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();

    }

        
    
}
