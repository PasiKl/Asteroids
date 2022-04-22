
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    const float MARGIN = 1.0f;

    float max_screen_x;
    float max_screen_y;
    float margin_x;
    float margin_y;

    float speed;

    Vector2 dir;


    private void Awake() 
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        speed = Random.Range(1, 6);
    }

    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2;
        max_screen_y = height / 2;

        margin_x = max_screen_x + MARGIN;
        margin_y = max_screen_y + MARGIN;



        // transform.position = new Vector2(Random.Range(-max_screen_x, max_screen_x), Random.Range(-max_screen_y, max_screen_y));

        dir = new Vector2(1.0f, 0.0f);

        float angle = Mathf.Deg2Rad * Random.Range(0, 359);

        dir = new Vector2(dir.x * Mathf.Cos(angle) - dir.y * Mathf.Sin(angle),
                          dir.x * Mathf.Sin(angle) + dir.y * Mathf.Cos(angle));

        dir.Normalize();

        dir *= speed;
        
        if(Random.Range(0, 2) == 0)
            Destroy(transform.Find("Satellite").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempDir = dir * Time.deltaTime;

        transform.Translate(tempDir, Space.World);

        float x = transform.position.x;
        float y = transform.position.y;

        x = x < -margin_x || x > margin_x ? -x : x;
        y = y < -margin_y || y > margin_y ? -y : y;

        transform.position = new Vector2(x, y);       
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ast")
            dir *= 0.0f;

        if(other.gameObject.tag == "Bull")
        {
            transform.DetachChildren();

            Destroy(this.gameObject);
        }   
    }

    public float getSpeed()
    {
        return speed;
    }
}
