using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    float speed = 10f;

    Controller controllerScript;


    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GameObject.Find("Manager").GetComponent<Controller>();

        Destroy(gameObject, 10);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        int s = 0;

        switch (other.gameObject.tag)
        {
            case "Ast":
                s = 10;

                break;
            case "Ast2":
                s = 20;

                break;
            case "Piece":
            case "Sat":
                s = 30;

                break;
        }

        controllerScript.UpdateScore(s);

        Destroy(gameObject);
    }
}
