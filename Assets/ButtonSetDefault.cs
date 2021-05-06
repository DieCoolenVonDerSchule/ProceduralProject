using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetDefault : MonoBehaviour
{
  

    public void setDefault()
    {

        // Setzen der Standartwerte

        GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text = "500";
        GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text = "500";
        GameObject.FindGameObjectWithTag("scalex").GetComponent<UnityEngine.UI.InputField>().text = "0,05";
       
        GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text = "0";
        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text = "0";
        GameObject.FindGameObjectWithTag("spreadx").GetComponent<UnityEngine.UI.InputField>().text = "1";
        GameObject.FindGameObjectWithTag("spready").GetComponent<UnityEngine.UI.InputField>().text = "6,5";
        GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text = "1";

        GameObject.FindGameObjectWithTag("maps").GetComponent<UnityEngine.UI.InputField>().text = "5";

    }
}
