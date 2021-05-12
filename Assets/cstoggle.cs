using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cstoggle : MonoBehaviour
{
    // Start is called before the first frame update

    public void changeShaderToggle()
    {

        if (GameObject.FindGameObjectWithTag("shadertoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {

            GameObject.FindGameObjectWithTag("threadingtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }




    }


    public void changeThreadingToggle()
    {

        if (GameObject.FindGameObjectWithTag("threadingtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {

            GameObject.FindGameObjectWithTag("shadertoggle").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }




    }




}
