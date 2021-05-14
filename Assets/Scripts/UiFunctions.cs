using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFunctions : MonoBehaviour
{


    public void setDefault()       // Setzen der Standartwerte
    {
        int sizex = 500;
        int sizey = 500;

        float scale = 0.015f;
        float coarse = 1.3f;
        float contrib = 6.5f;
        float output = 6.0f;

        int shiftx = 0;
        int shifty = 0;
        int maps = 5;
        int speed = 1;

        float plantscale = 1.0f;


        GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text = "" + sizex;
        GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text = "" + sizey;
        
        GameObject.FindGameObjectWithTag("scale").GetComponent<UnityEngine.UI.InputField>().text = "" + scale;
        GameObject.FindGameObjectWithTag("coarse").GetComponent<UnityEngine.UI.InputField>().text = "" + coarse;  
        GameObject.FindGameObjectWithTag("contrib").GetComponent<UnityEngine.UI.InputField>().text = "" + contrib;
        GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text = "" + output;
        GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text = "" + shiftx;
        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text = "" + shifty;

        GameObject.FindGameObjectWithTag("maps").GetComponent<UnityEngine.UI.InputField>().text = "" + maps;
        GameObject.FindGameObjectWithTag("speed").GetComponent<UnityEngine.UI.InputField>().text = "" + speed;

        GameObject.FindGameObjectWithTag("scaleslider").GetComponent<UnityEngine.UI.Slider>().value = scale;
        GameObject.FindGameObjectWithTag("coarseslider").GetComponent<UnityEngine.UI.Slider>().value = coarse;
        GameObject.FindGameObjectWithTag("contribslider").GetComponent<UnityEngine.UI.Slider>().value = contrib;
        GameObject.FindGameObjectWithTag("outputslider").GetComponent<UnityEngine.UI.Slider>().value = output;
        GameObject.FindGameObjectWithTag("shiftxslider").GetComponent<UnityEngine.UI.Slider>().value = shiftx;
        GameObject.FindGameObjectWithTag("shiftyslider").GetComponent<UnityEngine.UI.Slider>().value = shifty;

        GameObject.FindGameObjectWithTag("plantscale").GetComponent<UnityEngine.UI.InputField>().text = "" + plantscale;
    }


    public void setScale()      // Scale wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("scale").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("scaleslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setScaleField()      // Scale wird per Field verändert
    {
        string scaleStr = GameObject.FindGameObjectWithTag("scale").GetComponent<UnityEngine.UI.InputField>().text;
        float scaleSet = float.Parse(scaleStr);
        GameObject.FindGameObjectWithTag("scaleslider").GetComponent<UnityEngine.UI.Slider>().value = scaleSet;
    }



    public void setCoarse()     // Coarseness wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("coarse").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("coarseslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setCoarseField()     // Coarseness wird per Field verändert
    {
        string coarseStr = GameObject.FindGameObjectWithTag("coarse").GetComponent<UnityEngine.UI.InputField>().text;
        float coarseSet = float.Parse(coarseStr);
        GameObject.FindGameObjectWithTag("coarseslider").GetComponent<UnityEngine.UI.Slider>().value = coarseSet;
    }


    public void setContrib()    // Contribution wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("contrib").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("contribslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setContribField()    // Contribution wird per Field verändert
    {
        string contribStr = GameObject.FindGameObjectWithTag("contrib").GetComponent<UnityEngine.UI.InputField>().text;
        float contribSet = float.Parse(contribStr);
        GameObject.FindGameObjectWithTag("contribslider").GetComponent<UnityEngine.UI.Slider>().value = contribSet;
    }

    public void setShiftX()    // ShiftX wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("shiftxslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setShiftXField()    // ShiftX wird per Field verändert
    {
        string shiftxStr = GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text;
        int shiftxSet = int.Parse(shiftxStr);
        GameObject.FindGameObjectWithTag("shiftxslider").GetComponent<UnityEngine.UI.Slider>().value = shiftxSet;
    }


    public void setShiftY()     // ShiftY wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("shiftyslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setShiftYField()     // ShiftY wird per Field verändert
    {
        string shiftyStr = GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text;
        int shiftySet = int.Parse(shiftyStr);
        GameObject.FindGameObjectWithTag("shiftyslider").GetComponent<UnityEngine.UI.Slider>().value = shiftySet;
    }


    public void setOutput()     // Output wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("outputslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setOutputField()     // Output wird per Field verändert
    {
        string outputStr = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float outputSet = float.Parse(outputStr);
        GameObject.FindGameObjectWithTag("outputslider").GetComponent<UnityEngine.UI.Slider>().value = outputSet;
    }


    public void setPlantscale()     // Plantscale wird per Slider verändert
    {
        GameObject.FindGameObjectWithTag("plantscale").GetComponent<UnityEngine.UI.InputField>().text =
            GameObject.FindGameObjectWithTag("plantscaleslider").GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    public void setPlantscaleField()     // Plantscale wird per Field verändert
    {
        string plantscaleStr = GameObject.FindGameObjectWithTag("plantscale").GetComponent<UnityEngine.UI.InputField>().text;
        float plantscaleSet = float.Parse(plantscaleStr);
        GameObject.FindGameObjectWithTag("plantscaleslider").GetComponent<UnityEngine.UI.Slider>().value = plantscaleSet;
    }



    public void toggleMenu()      // Münü an-aus schalten
    {
        GameObject.FindGameObjectWithTag("canvas").GetComponent<UnityEngine.Canvas>().enabled = !GameObject.FindGameObjectWithTag("canvas").GetComponent<UnityEngine.Canvas>().enabled;
    }



    public void toggleShader()     // Compute Shader wird geklickt
    {
        if (GameObject.FindGameObjectWithTag("shadertoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            GameObject.FindGameObjectWithTag("threadingtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
    }


    public void toggleThreading()      // Threading wird geklickt
    {
        if (GameObject.FindGameObjectWithTag("threadingtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            GameObject.FindGameObjectWithTag("shadertoggle").GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
    }



    public void setPreset()
    {

       // switch (GameObject.FindGameObjectWithTag("presets").GetComponent<UnityEngine.UI.Dropdown>().value)
        





        if (GameObject.FindGameObjectWithTag("presets").GetComponent<UnityEngine.UI.Dropdown>().value == 1)
        {
            print("VALUE 1");
        }


    }

    


}
