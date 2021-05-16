using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationFunctions : MonoBehaviour
{

    ArrayList plantList;
    
    



    // Start is called before the first frame update
    void Start()
    {
        plantList = new ArrayList();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject toPlace;


    public void placePlants (float[,] heightmap, float scale, float plantHeightMin, float plantHeightMax, float occurance)
    {

        foreach (GameObject plant in plantList)
        {
            Destroy(plant);

        }

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

                    if (Random.value < (1 - Mathf.Pow(heightmap[i, j], 0.25f)) * Mathf.Pow(probabilityDistribution[i, j],2)*occurance) putPlant(i, j, heightmap[i, j]);

                 //   print("%: "+ (Mathf.Pow(heightmap[i, j], 0.25f) * Mathf.Pow(probabilityDistribution[i, j], 2) * occurance));
                 //   print("%: "+ (Mathf.Pow(probabilityDistribution[i, j], 2))+ " -> " + heightmap[i,j]);

  
               

                }

            }
        }

    }


    public void putPlant(int x, int y, float height)
    {


        string outputStr = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float output = float.Parse(outputStr);


        float offsetX = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.x;
        float offsetHeight = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.y;
        float offsetY = GameObject.FindGameObjectWithTag("MeshGenerator").transform.position.z;

        float scaleX = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.x;
        float scaleHeight = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.y;
        float scaleY = GameObject.FindGameObjectWithTag("MeshGenerator").transform.localScale.z;



        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //sphere.transform.position = new Vector3(x*scaleX+offsetX, height*scaleHeight*output+offsetHeight, y*scaleY+offsetY);


        toPlace.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


        plantList.Add(Instantiate(toPlace, new Vector3(x * scaleX + offsetX, height * scaleHeight * output + offsetHeight, y * scaleY + offsetY), Quaternion.identity));



        




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

        putPlant(i, j, heightmap[i,j]);

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
