using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    float max_screen_x;
    float max_screen_y;

    int lives, score;
    Color primaryCol, secondaryCol;

    [SerializeField] GameObject ast;
    [SerializeField] GameObject ship;
    [SerializeField] Text scoreText;


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

        primaryCol = new Color(1.0f, 0.0f, 0.0f);
        secondaryCol = new Color(0.0f, 1.0f, 0.0f);

        lives = 3;
        score = 0;

        // ship = GameObject.Find("Ship");
        // ship.GetComponent<ShipControls>().SetColors(primaryCol, secondaryCol);

        CreateShip();

        int n = Random.Range(2, 5);

//        n = 0;

        for(int i = 0; i < n; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-max_screen_x, max_screen_x), Random.Range(-max_screen_y, max_screen_y));

            if(Mathf.Abs(pos.x) < 1.0f && Mathf.Abs(pos.y) < 1.0f)
                pos = new Vector2(pos.x * 1.5f, pos.y * 1.5f);

            var a = Instantiate(ast, pos, Quaternion.identity);

            if(Random.Range(0.0f, 1.0f) < 0.5f)
                a.GetComponent<MoveAsteroid>().SetColors(primaryCol);
            else
                a.GetComponent<MoveAsteroid>().SetColors(secondaryCol);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateShip()
    {
        var s = Instantiate(ship, new Vector2(0.0f, 0.0f), Quaternion.identity);

        s.GetComponent<ShipControls>().SetColors(primaryCol, secondaryCol);
    }
    
    public void ShipDestroyed()
    {
        GameObject.Find($"Life{lives}").SetActive(false);

        lives--;

        Invoke("CreateShip", 3);
    }

    public void UpdateScore(int s)
    {
        score += s;

        scoreText.text = $"{score}";
    }
}
