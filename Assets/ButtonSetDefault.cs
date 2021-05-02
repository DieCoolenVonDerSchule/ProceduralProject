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

        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[5].text = "10";
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[4].text = "10";
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[3].text = "1.0";
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[2].text = "1.0";
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[1].text = "0";
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[0].text = "0";

        GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text = "50";
        GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text = "50";
        GameObject.FindGameObjectWithTag("scalex").GetComponent<UnityEngine.UI.InputField>().text = "1.0";
        GameObject.FindGameObjectWithTag("scaley").GetComponent<UnityEngine.UI.InputField>().text = "1.0";
        GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text = "0";
        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text = "0";



    }
}
