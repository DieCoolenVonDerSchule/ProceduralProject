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


    public static float[,] createHeightMapRandom(int x, int y)
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

    public static float[,] createHeightMapPerlinNoise(int x, int y, int mapcount)
    {

        //  int shiftInputX = int.Parse(GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[4].text);
        //  int shiftInputY = int.Parse(GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[5].text);

        int shiftInputX = int.Parse(GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text);
        int shiftInputY = int.Parse(GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text);


        float shiftx = Random.value*shiftInputX;
        float shifty = Random.value*shiftInputY;

        // string scaleInputX = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[1].text;
        // string scaleInputY = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[0].text;

        string scaleInputX = GameObject.FindGameObjectWithTag("scalex").GetComponent<UnityEngine.UI.InputField>().text;
        string scaleInputY = GameObject.FindGameObjectWithTag("scaley").GetComponent<UnityEngine.UI.InputField>().text;

        float scalex = float.Parse(scaleInputX);
        float scaley = float.Parse(scaleInputY);

        string spreadInputX = GameObject.FindGameObjectWithTag("spreadx").GetComponent<UnityEngine.UI.InputField>().text;
        string spreadInputY = GameObject.FindGameObjectWithTag("spready").GetComponent<UnityEngine.UI.InputField>().text;
        float spreadx = float.Parse(spreadInputX);
        float spready = float.Parse(spreadInputY);




        //TEST
        // GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[0].text = "0";


        float[,] heightmap = new float[x, y];
            


        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                heightmap[i, j] = Mathf.PerlinNoise((shiftx+(mapcount*spreadx))+(i*scalex),(shifty+(mapcount*spready))+(j*scaley));
            }
        }


        return heightmap;
    }



   

    public void GenerateRandom()
    {

        //string xinput = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[3].text;
        //string yinput = GameObject.FindObjectsOfType<UnityEngine.UI.InputField>()[2].text;

        string xinput = GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text;
        string yinput = GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text;


        int x = int.Parse(xinput);
        int y = int.Parse(yinput);


        float[,] heightmap = createHeightMapRandom(x, y);

        print(heightmap);

        var colors = GetComponent<UnityEngine.UI.Button>().colors;
        colors.pressedColor = Color.green;

        GetComponent<UnityEngine.UI.Button>().colors = colors;

        if (GameObject.FindGameObjectWithTag("debugtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            debugHeightMap(heightmap);
        }
        


    }


    public void GeneratePerlinNoise()
    {

        string xinput = GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text;
        string yinput = GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text;


        int x = int.Parse(xinput);
        int y = int.Parse(yinput);

        int mapcount = 2;

        float[,] heightmap1 = createHeightMapPerlinNoise(x, y, mapcount-1);
        float[,] heightmap2 = createHeightMapPerlinNoise(x, y, mapcount);

        

        var colors = GetComponent<UnityEngine.UI.Button>().colors;
        colors.pressedColor = Color.green;

        GetComponent<UnityEngine.UI.Button>().colors = colors;


        if (GameObject.FindGameObjectWithTag("debugtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            debugHeightMap(heightmap1);
            debugHeightMap(heightmap2);
        }


        // MAPS VERRECHNEN
        float[,] heightmap = createHeightMapRandom(x,y);
        
        for (int i=0; i<x; i++)
        {
            for (int j=0; j<y; i++)
            {
                heightmap[i, j] = heightmap1[i, j] + heightmap2[i, j];          // INDEX OUT OF BOUNDS
            }
        }
        
        GameObject.FindGameObjectWithTag("MeshGenerator").GetComponent<MeshGenerator>().generateMesh(heightmap1);


    }

    

    public void debugHeightMap(float[,] map)
    {
        float lowestHeight = 100;
        float highestHeight = 0;
        float lowestStep = 100;
        float highestStep = 0;
        float step = 0;
        float lastHeight = 0;


        for (int i=0; i<map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                print(map[i,j]);

                if (map[i, j] < lowestHeight) lowestHeight = map[i, j];
                if (map[i, j] > highestHeight) highestHeight = map[i, j];

                step = (map[i, j] - lastHeight);
                if (step < 0) step = step * (-1);

                if (step < lowestStep) lowestStep = step;
                if (step > highestStep) highestStep = step;


                
            }
            

        }

        print("------------------------");
        print("Lowest : " + lowestHeight);
        print("Highest: " +highestHeight);
        print("------------------------");
        print("Lowest Step : " + lowestStep);
        print("Highest Step: " + highestStep);
        print("------------------------");

    }

}
