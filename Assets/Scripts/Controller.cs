using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float max_screen_x;
    float max_screen_y;

    Color primaryCol, secondaryCol;

    GameObject ship;

    [SerializeField] GameObject ast;


    private void Awake() 
    {
        // Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        max_screen_x = width / 2.0f;
        max_screen_y = height / 2.0f;

        ship = GameObject.Find("Ship");

        primaryCol = new Color(1.0f, 0.0f, 0.0f);
        secondaryCol = new Color(0.0f, 1.0f, 0.0f);

        ship.GetComponent<ShipControls>().SetColors(primaryCol, secondaryCol);

        int n = Random.Range(2, 5);

        // Debug.Log(n);

        for(int i = 0; i < n; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-max_screen_x, max_screen_x), Random.Range(-max_screen_y, max_screen_y));

            if(Mathf.Abs(pos.x) < 1.0f && Mathf.Abs(pos.y) < 1.0f)
                pos = new Vector2(pos.x * 1.5f, pos.y * 1.5f);

            var a = Instantiate(ast, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
