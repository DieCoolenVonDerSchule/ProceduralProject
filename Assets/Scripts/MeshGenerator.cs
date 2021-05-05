using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    float[,] heightMap;
    int[] triangles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void generateMesh(float[,] map)
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        string xinput = GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text;
        string yinput = GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text;


        int x = int.Parse(xinput);
        int y = int.Parse(yinput);

        heightMap = map;
        //heightMap = GenerationFunctions.createHeightMapPerlinNoise(x, y, 1);

        createShape();
        updateMesh();
    }

    void createShape()
    {
        int x = heightMap.GetLength(0)-1;
        int y = heightMap.GetLength(1)-1;
        vertices = new Vector3[(x+1) * (y+1)];

        int k = 0;
        for(int i = 0; i<y+1; i++)
        {
            for(int j = 0; j<x+1; j++)
            {
                vertices[k] = new Vector3(j, heightMap[j, i]*2f, i);
                k++;
            }
        }

        triangles = new int[x * y * 6];
        int vert = 0;
        int tris = 0;

        for(int i = 0; i<y; i++)
        {
            for(int j = 0; j<x; j++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + x + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + x + 1;
                triangles[tris + 5] = vert + x + 2;

                vert++;
                tris += 6;
            }

            vert++;
        }
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
