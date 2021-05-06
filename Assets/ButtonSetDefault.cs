using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetDefault : MonoBehaviour
{
    // Start is called before the first frame update
    // InputField[5] -> array size X
    // InputField[4] -> array size Y
    // InputField[3] -> perlin scale X
    // InputField[2] -> perlin scale Y
    // InputField[1] -> shift x
    // InputField[0] -> shift y


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
