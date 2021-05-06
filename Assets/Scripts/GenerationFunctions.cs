using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GenerationFunctions : MonoBehaviour
{


    public static Vector2[] startwerte;
    float timer = 0f;
    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("movetoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                timer -= 1f;
                moveUp();
            }

        }


            
        
    }


    public static void initializeConstants(int mapcount)
    {
        startwerte = new Vector2[mapcount];
            
        if (startwerte == null)
        {
            for (int i = 0; i < mapcount; i++)
            {
                startwerte[i] = new Vector2(Random.Range(0, 1000), Random.Range(0, 1000));
            }


        }

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



    public static float[,] createHeightMapPerlinNoise(int x, int y, float scale, float startx, float starty)
    {

      
        float shiftx = float.Parse(GameObject.FindGameObjectWithTag("shiftx").GetComponent<UnityEngine.UI.InputField>().text);
        float shifty = float.Parse(GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text);
           
       
    
        float[,] heightmap = new float[x, y];

        

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                heightmap[i, j] = (Mathf.PerlinNoise(startx+(shiftx+i)*scale, starty+(shifty+j) * scale)*2)-1;
            }
        }


        return heightmap;
    }



   

    public void GenerateRandom()
    {

     
        string xinput = GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text;
        string yinput = GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text;


        int x = int.Parse(xinput);
        int y = int.Parse(yinput);


        float[,] heightmap = createHeightMapRandom(x, y);

        

        

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

        string scaleInput = GameObject.FindGameObjectWithTag("scalex").GetComponent<UnityEngine.UI.InputField>().text;
        float scale = float.Parse(scaleInput);


        string coarseInput = GameObject.FindGameObjectWithTag("spreadx").GetComponent<UnityEngine.UI.InputField>().text;
        string contributionInput = GameObject.FindGameObjectWithTag("spready").GetComponent<UnityEngine.UI.InputField>().text;

        float coarse = float.Parse(coarseInput);
        float contribution = float.Parse(contributionInput);


        if (GameObject.FindGameObjectWithTag("debugtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            print("scaleInput: " + scaleInput);
            print("scale     : " + scale);


        }


        string mapsinput = GameObject.FindGameObjectWithTag("maps").GetComponent<UnityEngine.UI.InputField>().text;
        int mapcount = int.Parse(mapsinput);


        
        initializeConstants(mapcount);


        
        

        float[][,] heightmaps = new float[mapcount][,];

       

        for (int i=0; i<mapcount; i++)
        {
            heightmaps[i] = createHeightMapPerlinNoise(x, y, scale * Mathf.Pow(i+1,coarse),startwerte[i].x, startwerte[i].y);
        }


        float[,] heightmapCombined = new float[x, y];
        for (int i=0; i<mapcount; i++)
        {
            for (int j=0; j<x; j++)
            {
                for (int k=0; k<y; k++)
                {
                    heightmapCombined[j, k] += (heightmaps[i][j, k]/((i*contribution+1)));
                }
            }
            
        }

        float highest = 0;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (Mathf.Abs(heightmapCombined[i, j]) > highest) highest = Mathf.Abs(heightmapCombined[i, j]);
            }
        }

        
        string outputInput = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float output = float.Parse(outputInput);
        
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                heightmapCombined[i, j] = output * (heightmapCombined[i, j] / highest ) ;
            }
        }

        


        if (GameObject.FindGameObjectWithTag("debugtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            debugHeightMap(heightmapCombined);
            
        }


        

        GameObject.FindGameObjectWithTag("MeshGenerator").GetComponent<MeshGenerator>().generateMesh(heightmapCombined);


        

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
        print("Highest: " + highestHeight);
        print("------------------------");
        print("Lowest Step : " + lowestStep);
        print("Highest Step: " + highestStep);
        print("------------------------");

    }




    public void moveUp()
    {

        string step = GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text;

        int shiftstep = int.Parse(step);
        shiftstep++;


        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text = "" + shiftstep;


        GeneratePerlinNoise();



    }


    public void moveDown()
    {

        string step = GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text;

        int shiftstep = int.Parse(step);
        shiftstep--;


        GameObject.FindGameObjectWithTag("shifty").GetComponent<UnityEngine.UI.InputField>().text = "" + shiftstep;


        GeneratePerlinNoise();



    }
}
