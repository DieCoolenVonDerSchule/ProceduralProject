using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void placePlants (float[,] heightmap, float scale)
    {

        int x = heightmap.GetLength(0);
        int y = heightmap.GetLength(1);

        float startx = Random.Range(0, 1000);
        float starty = Random.Range(0, 1000);


        

        float[,] probabilityDistribution = GameObject.FindGameObjectWithTag("heightmapbutton").GetComponent<GenerationFunctions>().createHeightMapPerlinNoiseCS(x, y, scale, startx, starty, 0, 0);




        for (int i=0; i<x; i++)
        {
            for (int j=0; j<y; j++)
            {
              
                if (Random.value < (1 - Mathf.Pow(heightmap[i, j],0.25f)) * probabilityDistribution[i, j]) putPlant(i, j, heightmap[i,j]);

                }
        }

    }


    public static void putPlant(int x, int y, float height)
    {


        string outputStr = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float output = float.Parse(outputStr);


        float offsetX = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.x;
        float offsetHeight = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.y;
        float offsetY = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.z;

        float scaleX = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.x;
        float scaleHeight = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.y;
        float scaleY = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.z;


        
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = new Vector3(x*scaleX+offsetX, height*scaleHeight*output+offsetHeight, y*scaleY+offsetY);

        




    }


    public static void placePlants2(float[,] heightmap, float scale)
    {


        int x = heightmap.GetLength(0);
        int y = heightmap.GetLength(1);


        float plantProbability = 0.001f;   // wahrscheinlichkeit dass eine pflanze entsteht(0 bis 1)
        float plantHeightMax = 0.5f;    // maximale höhe damit pflanze wachsen kann (0 bis 1)
        float plantHeightMin = 0.0f;    // minimale höhe damit pflanze wachsen kann (0 bis 1)




        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {


                if (Random.value < plantProbability && heightmap[i,j]<plantHeightMax && heightmap[i,j]>plantHeightMin) seedPlants(i, j, heightmap); 
                        
                        

            }
        }



    }


    public static void seedPlants(int i, int j, float[,] heightmap)
    {

        int seedRadius = 3;            // Radius der Verbreitung der Pflanze  (1 bis mapsize)
        float seedProbability = 0.2f;    // Wahrscheinlichkeit der Verbreitung  (0 bis 1)


        putPlant(i, j, heightmap[i,j]);
        if (Random.value < seedProbability) seedPlants(i-seedRadius, j, heightmap);
        if (Random.value < seedProbability) seedPlants(i+seedRadius, j, heightmap);
        if (Random.value < seedProbability) seedPlants(i, j-seedRadius, heightmap);
        if (Random.value < seedProbability) seedPlants(i, j+seedRadius, heightmap);


    }
}
