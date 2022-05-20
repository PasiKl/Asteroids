using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ColorChange", 1);

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColorChange()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.4f, 0.0f);
    }
}
