using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject crossPrefab, bonusPrefab, foodPrefab;
    Rigidbody2D rb;
    //int chances = 3;
    public float moveSpeed;
    public float rotateAmount;
    public int life = 3;
    private int score = 0,highscore =0;
    float rot;
    //public GameObject GameOver, Restart;
    public Text scoreText, highScoreText, lifeText;
    //public Text lifeText;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        highScoreText.text = "HighScore: " + highscore;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("called");
        if(Input.GetMouseButton(0))
        {
            //Debug.Log(Input.mousePosition);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.x<0)
            {
                rot = rotateAmount;
            }
            else 
            {
                rot = -rotateAmount;
            }
            transform.Rotate(0,0,rot);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float posX=Random.Range(-2f,2f);
       float posY = Random.Range(-4f,3f);
        if (life > 0)
        {
            if (collision.gameObject.tag == "Food")
            {
                Destroy(collision.gameObject);
                score++;
                Instantiate(foodPrefab, new Vector3(posX, posY, 0), transform.rotation);
            }
            else if (collision.gameObject.tag == "bonus")
            {
                Destroy(collision.gameObject);
                score += 5;
                Instantiate(bonusPrefab, new Vector3(posX, posY, 0), transform.rotation);

            }
            else if (collision.gameObject.tag == "Danger")
            {
                life--;
                Destroy(collision.gameObject);
                Instantiate(crossPrefab, new Vector3(posX, posY, 0), transform.rotation);
                if (life == 0)
                {
                    //Debug.Log(chances);
                    SceneManager.LoadScene("Restart");
                }

            }
        }
        UpdateHighScore();
        scoreText.text = "Score: "+score;
        highScoreText.text = "HighScore: " + highscore;
        lifeText.text = "Life: " + life;
        PlayerPrefs.SetInt("currentScore", score);
    }

    private void UpdateHighScore()
    {
        if(score>highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
     public void GoToRestart()
    {
        SceneManager.LoadScene("Restart");
    }
}
