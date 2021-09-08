using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float camXi = 0, camYi = -965, speed = 2.0f; 

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 temp = transform.position;

        if (temp.y <= 9000.0f*Time.deltaTime)
        {
            temp.y += (2.0f * Time.deltaTime);
            transform.position = temp;
        }

        else
        {
            temp.y -= 20000.0f*Time.deltaTime;
            transform.position = temp;
        }
        
        
    }
}
