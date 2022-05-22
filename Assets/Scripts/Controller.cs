using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Controller : MonoBehaviour
{
    float max_screen_x;
    float max_screen_y;

    int lives, score;
    Color primaryCol, secondaryCol;

    GameObject GOText;
    GameObject shipInst;
    
    [SerializeField] GameObject ast;
    [SerializeField] GameObject ship;
    [SerializeField] Text scoreText;


    private void Awake() 
    {
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

        CreateShip();
        CreateAsteroids();

        GOText = GameObject.Find("GameOverText");

        GOText.SetActive(false);
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire3"))
        {
            Destroy(shipInst);

            CreateShip();
            CreateAsteroids();
        }
    }

    public void CreateAsteroids()
    {
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

    public void CreateShip()
    {
        shipInst = Instantiate(ship, new Vector2(0.0f, 0.0f), Quaternion.identity);
 
        shipInst.GetComponent<ShipControls>().SetColors(primaryCol, secondaryCol);
    }
    
    public void ShipDestroyed()
    {
        GameObject.Find($"Life{lives}").SetActive(false);

        lives--;

        if (lives == 0)
        {
            GOText.SetActive(true);

            Invoke("ShowStartScreen", 3);
        }
        else
            Invoke("CreateShip", 3);
    }

    private void ShowStartScreen()
    {
        SceneManager.LoadScene("Start");
    }

    public void UpdateScore(int s)
    {
        score += s;

        scoreText.text = $"{score}";
    }
}
