using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    const float MARGIN = 0.5f;

    float max_screen_x;
    float max_screen_y;
    float margin_x;
    float margin_y;

    float speed = 5f;
    float rotationSpeed = 200f;


    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2;
        max_screen_y = height / 2;

        //Debug.Log(max_screen_x);
        //Debug.Log(max_screen_y);

        margin_x = max_screen_x + MARGIN;
        margin_y = max_screen_y + MARGIN;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        float rot = rotationSpeed * Time.deltaTime * h;

        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -rot);

        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);

        float x = transform.position.x;
        float y = transform.position.y;

        x = x < -margin_x || x > margin_x ? -x : x;
        y = y < -margin_y || y > margin_y ? -y : y;

        transform.position = new Vector2(x, y);
    }
}
