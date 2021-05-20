using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Camera camera;
    public MeshGenerator meshgen;
    public static Vector3 meshposition;

    public static float threshold;
    public static int sectionCount;
   

    //public float sizex;
    public static int sizey;
    public static float scale;
    public static float coarse;
    public static float contrib;
  
    public GenerationFunctions generations;

    public static Vector3 genPos;

    public static List<MeshGenerator> meshGenerators;


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
        scale = float.Parse(GameObject.FindGameObjectWithTag("scale").GetComponent<UnityEngine.UI.InputField>().text);
        coarse = float.Parse(GameObject.FindGameObjectWithTag("coarse").GetComponent<UnityEngine.UI.InputField>().text);
        contrib = float.Parse(GameObject.FindGameObjectWithTag("contrib").GetComponent<UnityEngine.UI.InputField>().text);

        float offset = meshposition.z;
        threshold = offset + sizey / 2;

        sectionCount = 1;

        genPos = meshposition;

        meshGenerators = new List<MeshGenerator>();
    }


    public void moveUp(float speed)
    {

        
       


        Vector3 pos = camera.transform.position;
        
        pos.z += speed*Time.deltaTime;
        camera.transform.position = pos;

        if (pos.z > threshold)
        {

            for (int i = 0; i < GenerationFunctions.startwerte.Length; i++)
            {

                GenerationFunctions.startwerte[i].y += (sizey - 1)*scale * Mathf.Pow(i + 1, coarse);

            }

            MeshGenerator newMeshGenerator = Instantiate(meshgen);



            float localScale = meshgen.transform.localScale.z;



            Vector3 newPosition = genPos;
            
         
            newPosition.z += (sizey - 2) * localScale;

           // print(sizey);


            newMeshGenerator.transform.position = newPosition;

            
            generations.GeneratePerlinNoise(newMeshGenerator);


            meshGenerators.Add(newMeshGenerator);
            threshold += (sizey - 2) * localScale;
            genPos.z += (sizey - 2) * localScale;

            sectionCount++;

            //
           

            if (sectionCount == 4)
            {

                //print("count: "+sectionCount);
                print(meshGenerators.Count);


              
                Destroy(meshGenerators[0].gameObject);
                meshGenerators.RemoveAt(0);
                sectionCount--;

            }
            
          
            

            
            
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
