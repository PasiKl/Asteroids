using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSatellite : MonoBehaviour
{
    const float MARGIN = 0.5f;

    float max_screen_x;
    float max_screen_y;
    float margin_x;
    float margin_y;

    bool set = false;

    Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2;
        max_screen_y = height / 2;

        margin_x = max_screen_x + MARGIN;
        margin_y = max_screen_y + MARGIN;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 0.2f);

        if(transform.parent != null)
            transform.RotateAround(transform.parent.position, Vector3.forward, 0.3f);
        else
        {
            if(!set)
            {
                dir = transform.up;

                set = true;
            }

            transform.Translate(dir * 2f * Time.deltaTime, Space.World);

            float x = transform.position.x;
            float y = transform.position.y;

            x = x < -margin_x || x > margin_x ? -x : x;
            y = y < -margin_y || y > margin_y ? -y : y;

            transform.position = new Vector2(x, y);       
        }
    }
}
