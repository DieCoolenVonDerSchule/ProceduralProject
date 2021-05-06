using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMenu : MonoBehaviour
{

    public void toggleMenu()
    {


        
        GameObject.FindGameObjectWithTag("canvas").GetComponent<UnityEngine.Canvas>().enabled = !GameObject.FindGameObjectWithTag("canvas").GetComponent<UnityEngine.Canvas>().enabled;




    }



}
