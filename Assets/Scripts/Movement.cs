using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void moveUp(float speed)
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.z += speed*Time.deltaTime;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

        print(pos.z);
        
    }

    public void moveUp()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position;
        pos.z++;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = pos;

        print(pos.z);

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
