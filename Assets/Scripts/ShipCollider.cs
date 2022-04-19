using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(this.gameObject);
    }
}
