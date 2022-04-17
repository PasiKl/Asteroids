
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    const float MAX_SCREEN_X = 14;
    const float MAX_SCREEN_Y = 5;
    const float MARGIN_X = MAX_SCREEN_X + MARGIN;
    const float MARGIN_Y = MAX_SCREEN_Y + MARGIN;
    const float MARGIN = 1.5f;

    float speed;

    Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        transform.position = new Vector2(Random.Range(-MAX_SCREEN_X, MAX_SCREEN_X), Random.Range(-MAX_SCREEN_Y, MAX_SCREEN_Y));

        dir = new Vector2(1.0f, 0.0f);

        float angle = Mathf.Deg2Rad * Random.Range(0, 359);

        dir = new Vector2(dir.x * Mathf.Cos(angle) - dir.y * Mathf.Sin(angle),
                          dir.x * Mathf.Sin(angle) + dir.y * Mathf.Cos(angle));

        dir.Normalize();

        speed = Random.Range(1, 10);

        dir *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempDir = dir * Time.deltaTime;

        transform.Translate(tempDir, Space.World);

        float x = transform.position.x;
        float y = transform.position.y;

        x = x < -MARGIN_X || x > MARGIN_X ? -x : x;       
        y = y < -MARGIN_Y || y > MARGIN_Y ? -y : y;

        transform.position = new Vector2(x, y);       
    }
}
