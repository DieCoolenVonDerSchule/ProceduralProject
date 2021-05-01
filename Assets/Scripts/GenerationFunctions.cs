using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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


    public void Generate()
    {
        float[,] heightmap = createHeightMapRandom(10, 10);

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
