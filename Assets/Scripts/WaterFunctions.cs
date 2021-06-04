﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaterFunctions : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    public int waterDetailX;
    public int waterDetailY;
    public int wasserspiegel;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        createShape();
        updateShape();
    }

    void createShape()
    {

        vertices = new Vector3[(waterDetailX + 1) * (waterDetailY + 1)];

        for (int i = 0, ind = 0; i<=waterDetailY; i++)
        {
            for(int j = 0; j<=waterDetailX; j++)
            {
                vertices[ind] = new Vector3(j, wasserspiegel, i);
                ind++;
            }
        }

        int vert = 0;
        int tris = 0;

        triangles = new int[waterDetailX * waterDetailY * 6];
        for(int j = 0; j<waterDetailY; j++)
        {
            for (int i = 0; i < waterDetailX; i++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + waterDetailX + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + waterDetailX + 1;
                triangles[tris + 5] = vert + waterDetailX + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void updateShape()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

}
