using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GenerationFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float[,] createHeightMapRandom(int x, int y)
    {
        float[,] heightmap = new float[x, y];

        for (int i=0; i<x; i++)
        {
            for (int j=0; j<y; j++)
            {
                heightmap[i, j] = Random.value;
            }
        }


        return heightmap;
    }



    // InputField[5] -> array size X
    // InputField[4] -> array size Y
    // InputField[3] -> perlin scale X
    // InputField[2] -> perlin scale Y
    // InputField[1] -> shift x
    // InputField[0] -> shift y

    public float[,] createHeightMapPerlinNoise(int x, int y)
    {

        

        int shiftInputX = int.Parse(GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[4].text);
        int shiftInputY = int.Parse(GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[5].text);


        float shiftx = Random.value*shiftInputX;
        float shifty = Random.value*shiftInputY;

        string scaleInputX = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[1].text;
        string scaleInputY = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[0].text;


        float scalex = float.Parse(scaleInputX);
        float scaley = float.Parse(scaleInputY);


       

        //TEST
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[0].text = "0";


        float[,] heightmap = new float[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                heightmap[i, j] = Mathf.PerlinNoise(shiftx+(i*scalex),shifty+(j*scaley));
            }
        }


        return heightmap;
    }





    public void GenerateRandom()
    {

        string xinput = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[3].text;
        string yinput = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[2].text;

        //string xinput2 = GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text;


        int x = int.Parse(xinput);
        int y = int.Parse(yinput);


        float[,] heightmap = createHeightMapRandom(x, y);

        print(heightmap);

        var colors = GetComponent<UnityEngine.UI.Button>().colors;
        colors.pressedColor = Color.red;

        GetComponent<UnityEngine.UI.Button>().colors = colors;

        debugHeightMap(heightmap);


    }


    public void GeneratePerlinNoise()
    {
        float[,] heightmap = createHeightMapPerlinNoise(10, 10);

        print(heightmap);

        var colors = GetComponent<UnityEngine.UI.Button>().colors;
        colors.pressedColor = Color.red;

        GetComponent<UnityEngine.UI.Button>().colors = colors;

        debugHeightMap(heightmap);


    }


    public void debugHeightMap(float[,] map)
    {

        for (int i=0; i<map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                print(map[i,j]);

            }
            

        }

    }

}
