using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    const float FIRING_SPEED = 0.1f;
    const float MARGIN = 0.5f;
    const float NOT_DESTROYED_TIME = 3.0f;

    float max_screen_x;
    float max_screen_y;
    float margin_x;
    float margin_y;

    float fs;
    float force = 5f;
    float speed = 10f;
    float rotationSpeed = 200f;


    bool destroyEnabled;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject trail;

    Color currentCol, primaryCol, secondaryCol;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2;
        max_screen_y = height / 2;

        margin_x = max_screen_x + MARGIN;
        margin_y = max_screen_y + MARGIN;
    
        rb = GetComponent<Rigidbody2D>();

        fs = FIRING_SPEED;
    
        // destroyEnabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;

        Invoke("ToggleDestroy", NOT_DESTROYED_TIME);

        StartCoroutine("ChangeColor");
    }

    private void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * force);
            
            if(rb.velocity.magnitude > speed)
                rb.velocity = rb.velocity.normalized * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fs -= Time.deltaTime;

        if(Input.GetButtonDown("Fire2"))
        {
            if(currentCol == primaryCol)
                currentCol = secondaryCol;
            else
                currentCol = primaryCol;
        }

        if(Input.GetButton("Fire1") && fs < 0f)
        {
            var b = Instantiate(bullet, transform.position + transform.up * 0.5f, transform.rotation);
        
            b.GetComponent<SpriteRenderer>().color = currentCol;

            fs = FIRING_SPEED;
        }

        if(rb.velocity.magnitude > 0.0f)
        {
            var v = new Vector3(rb.velocity.x, rb.velocity.y, transform.position.z);

            v.Normalize();

            var t = Instantiate(trail, transform.position + -v * 0.7f, transform.rotation);
            
            t.GetComponent<SpriteRenderer>().color = currentCol;

            Physics2D.IgnoreCollision(t.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        float h = Input.GetAxis("Horizontal");

        float rot = rotationSpeed * Time.deltaTime * h;

        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -rot);

        float x = transform.position.x;
        float y = transform.position.y;

        x = x < -margin_x || x > margin_x ? -x : x;
        y = y < -margin_y || y > margin_y ? -y : y;

        transform.position = new Vector2(x, y);
    }

    IEnumerator ChangeColor()
    {
        if(!destroyEnabled)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f);

            for(float t = 0.0f, i = 0.0f; i < NOT_DESTROYED_TIME; i += Time.deltaTime)
            {
                t = (1.0f / NOT_DESTROYED_TIME) * i;

                GetComponent<SpriteRenderer>().color = new Color(t, t, 1.0f);

                yield return null;
            }
        }
    }

    public void SetColors(Color pri, Color sec)
    {
        primaryCol = pri;
        secondaryCol = sec;

        currentCol = primaryCol;
    }

    public void ToggleDestroy()
    {
        destroyEnabled = !destroyEnabled;

        GetComponent<PolygonCollider2D>().enabled = destroyEnabled;
    }
}
