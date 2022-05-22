using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollider : MonoBehaviour
{
    bool noParent;

    Color col;


    // Start is called before the first frame update
    void Start()
    {
        noParent = false;

        var p = transform.parent;

        if (p)
            col = p.GetComponent<SpriteRenderer>().color;
        else
            noParent = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (noParent)
            Destroy(gameObject);
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
