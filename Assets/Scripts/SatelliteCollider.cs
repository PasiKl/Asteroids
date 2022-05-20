using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollider : MonoBehaviour
{
    Color col;


    // Start is called before the first frame update
    void Start()
    {
        col = transform.parent.GetComponent<SpriteRenderer>().color;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Bull")
        {
            if(other.gameObject.GetComponent<SpriteRenderer>().color == col)
                Destroy(gameObject);
        }
        else if(other.gameObject.tag != "Piece")
            Destroy(gameObject);
    }
}
