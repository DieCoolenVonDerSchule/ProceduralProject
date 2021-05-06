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
    Color[] colors;
    public Gradient gradient;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void generateMesh(float[,] map)
    {
        Destroy(GetComponent<MeshFilter>().mesh);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
      

        heightMap = map;
       

        createShape();
        updateMesh();
    }

    void createShape()
    {
        int x = heightMap.GetLength(0)-1;
        int y = heightMap.GetLength(1)-1;
        vertices = new Vector3[(x+1) * (y+1)];

        string outputInput = GameObject.FindGameObjectWithTag("output").GetComponent<UnityEngine.UI.InputField>().text;
        float output = float.Parse(outputInput);


        for (int k = 0, i = 0; i<y+1; i++)
        {
            for(int j = 0; j<x+1; j++)
            {
                vertices[k] = new Vector3(j, heightMap[j, i], i);
                k++;
            }
        }

        colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            colors[i] = gradient.Evaluate(vertices[i].y);
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = vertices[i].y * output;
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

        

        if (GameObject.FindGameObjectWithTag("debugtoggle").GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            print("vert: " + vert);
        }
            
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();


    }
}
