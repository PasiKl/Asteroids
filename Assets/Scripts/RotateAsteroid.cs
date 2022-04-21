using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -0.1f);

        // Transform child = transform.Find("Satellite");

        // if(child != null)
        // {
        //     child.GetComponent<RotateSatellite>()
        //     // child.transform.Rotate(Vector3.forward, 0.2f);

        //     // child.transform.RotateAround(transform.position, Vector3.forward, 0.3f);
        // }    
    }
}
