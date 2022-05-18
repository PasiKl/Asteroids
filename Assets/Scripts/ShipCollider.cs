using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    [SerializeField] GameObject trail;


    private void Start() 
    {
        // Physics2D.IgnoreCollision(trail.transform.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag != "Trail")
            Destroy(gameObject);
    }
}
