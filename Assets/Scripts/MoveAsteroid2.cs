using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid2 : MonoBehaviour
{
    const float MARGIN = 1.0f;

    float max_screen_x;
    float max_screen_y;
    float margin_x;
    float margin_y;

    float speed;

    Color col;

    Vector2 dir;

    [SerializeField] GameObject astPiece;


    private void Awake() 
    {
        speed = Random.Range(1.0f, 4.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2.0f;
        max_screen_y = height / 2.0f;

        margin_x = max_screen_x + MARGIN;
        margin_y = max_screen_y + MARGIN;

        // transform.position = new Vector2(Random.Range(-max_screen_x, max_screen_x), Random.Range(-max_screen_y, max_screen_y));

        dir = new Vector2(1.0f, 0.0f);

        float angle = Mathf.Deg2Rad * Random.Range(0.0f, 359.0f);

        dir = new Vector2(dir.x * Mathf.Cos(angle) - dir.y * Mathf.Sin(angle),
                          dir.x * Mathf.Sin(angle) + dir.y * Mathf.Cos(angle));

        dir.Normalize();

        dir *= speed;
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
        switch(other.gameObject.tag)
        {
            case "Ast":
            case "Ast2":
                CreateAsteroids();

                Destroy(gameObject);

                break;

            case "Bull":
                if(other.gameObject.GetComponent<SpriteRenderer>().color == col)
                {
                    CreateAsteroids();

                    Destroy(gameObject);
                }

                break;
        }
    }

    private void CreateAsteroids()
    {
        var pos = new Vector2(transform.position.x, transform.position.y);

        int n = Random.Range(2, 4);

        for(int i = 0; i < n; i++)
        {
            var p = Instantiate(astPiece, new Vector2(pos.x + Random.value, pos.y + Random.value), Quaternion.identity);
            
            p.GetComponent<MovePiece>().SetColors(GetComponent<SpriteRenderer>().color);
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public void SetColors(Color c)
    {
        col = c;
        
        GetComponent<SpriteRenderer>().color = c;
    }
}

