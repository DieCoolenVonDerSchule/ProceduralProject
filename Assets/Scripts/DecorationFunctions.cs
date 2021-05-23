using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshGenerator))]

public class DecorationFunctions : MonoBehaviour
{

    public List<GameObject> plantList;

    

    


    // Start is called before the first frame update
    void Start()
    {
        plantList = new List<GameObject>();
        print("PLANT START");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject toPlace;


    public void placePlants (float[,] heightmap, float scale, float plantHeightMin, float plantHeightMax, float occurance)
    {

        /*
        foreach (GameObject plant in plantList)
        {
            Destroy(plant);

        }
        */

        int x = heightmap.GetLength(0);
        int y = heightmap.GetLength(1);

        float startx = Random.Range(0, 1000);
        float starty = Random.Range(0, 1000);


        

        float[,] probabilityDistribution = GameObject.FindGameObjectWithTag("heightmapbutton").GetComponent<GenerationFunctions>().createHeightMapPerlinNoiseCS(x, y, scale, startx, starty, 0, 0);


        

        for (int i=0; i<x; i++)
        {
            for (int j=0; j<y; j++)
            {
              
                if (heightmap[i,j] > plantHeightMin && heightmap[i,j] < plantHeightMax)
                {

                    if (Random.value < (1 - Mathf.Pow(heightmap[i, j], 0.25f)) * Mathf.Pow(probabilityDistribution[i, j],2)*occurance) putPlant(i, j, heightmap[i, j], GetComponent<MeshGenerator>());

                          

                }

            }
        }

    }


    public void putPlant(int x, int y, float height, MeshGenerator meshgen)
    {


        string outputStr = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float output = float.Parse(outputStr);


        float offsetX = meshgen.transform.position.x;
        float offsetHeight = meshgen.transform.position.y;
        float offsetY = meshgen.transform.position.z;

        float scaleX = meshgen.transform.localScale.x;
        float scaleHeight = meshgen.transform.localScale.y;
        float scaleY = meshgen.transform.localScale.z;



        toPlace.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


        plantList.Add(Instantiate(toPlace, new Vector3(x * scaleX + offsetX, height * scaleHeight * output + offsetHeight, y * scaleY + offsetY), Quaternion.Euler(0f, -90f+Random.Range(-20f, 20f), 0f))); 








    }


    public void placePlants2(float[,] heightmap, float plantProbability, float plantHeightMin, float plantHeightMax, int seedRadius, float seedProbability)
    {

        
        foreach (GameObject plant in plantList)
        {
            Destroy(plant);

        }
        

        int x = heightmap.GetLength(0);
        int y = heightmap.GetLength(1);



        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {

                if (Random.value < plantProbability && heightmap[i,j]<plantHeightMax && heightmap[i,j]>plantHeightMin) seedPlants(i, j, heightmap, seedRadius, seedProbability); 
                               
            }
        }

    }


    public void seedPlants(int i, int j, float[,] heightmap, int seedRadius, float seedProbability)
    {

        putPlant(i, j, heightmap[i,j], GetComponent<MeshGenerator>());

        if (i - seedRadius < 0) seedRadius = 0;
        if (j - seedRadius < 0) seedRadius = 0;
        if (i + seedRadius > heightmap.GetLength(0)-1) seedRadius = 0;
        if (j + seedRadius > heightmap.GetLength(1)-1) seedRadius = 0;
        
        //if (i + seedRadius > 100) seedRadius = 0;
        //if (j + seedRadius > 100) seedRadius = 0;


        if (Random.value < seedProbability && seedRadius > 1) seedPlants(i-seedRadius, j, heightmap, seedRadius-1, seedProbability);
        if (Random.value < seedProbability && seedRadius > 1) seedPlants(i+seedRadius, j, heightmap, seedRadius-1, seedProbability);
        if (Random.value < seedProbability && seedRadius > 1) seedPlants(i, j-seedRadius, heightmap, seedRadius-1, seedProbability);
        if (Random.value < seedProbability && seedRadius > 1) seedPlants(i, j+seedRadius, heightmap, seedRadius-1, seedProbability);


    }
}
