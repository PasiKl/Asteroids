using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    [SerializeField] GameObject trail;
    // [SerializeField] 
    GameObject manager;


    private void Start() 
    {
        manager = GameObject.Find("Manager");
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag != "Trail")
        {
            manager.GetComponent<Controller>().ShipDestroyed();

            Destroy(gameObject);
        }
    }
}
