using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Camera camera;
    public MeshGenerator meshgen;
    public static Vector3 meshposition;

    public static float threshold;
   

    //public float sizex;
    public static int sizey;
  
    public GenerationFunctions generations;

    public static Vector3 genPos;

    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //meshgen = GameObject.FindGameObjectWithTag("meshgenerator").GetComponent<MeshGenerator>();

        
        


        generations = GameObject.FindGameObjectWithTag("heightmapbutton").GetComponent<GenerationFunctions>();

        meshposition = meshgen.transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void initializeConstants()
    {

     

      //  sizex = int.Parse(GameObject.FindGameObjectWithTag("sizex").GetComponent<UnityEngine.UI.InputField>().text);
        sizey = int.Parse(GameObject.FindGameObjectWithTag("sizey").GetComponent<UnityEngine.UI.InputField>().text);
        
        float offset = meshposition.z;
        threshold = offset + sizey / 2;

        genPos = meshposition;
    }


    public void moveUp(float speed)
    {

        
       


        Vector3 pos = camera.transform.position;
        
        pos.z += speed*Time.deltaTime;
        camera.transform.position = pos;

        if (pos.z > threshold)
        {

            MeshGenerator newMeshGenerator = Instantiate(meshgen);
            

            Vector3 newPosition = genPos;
            
         
            newPosition.z += sizey;
           // print(sizey);


            newMeshGenerator.transform.position = newPosition;
                      
            
            generations.GeneratePerlinNoise(newMeshGenerator);


           
            threshold += sizey;
            genPos.z += sizey;

            
            
        }

      //  print(pos.z);
        
    }

    public void moveUp()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.z++;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

       // print(pos.z);

        

    }



    public void moveDown()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.z--;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

    }

    public void moveLeft()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.x--;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

    }

    public void moveRight()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.x++;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

    }





}
