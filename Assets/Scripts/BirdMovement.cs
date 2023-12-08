using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isJumping;
    private float score = 0;
    public float highscore = 0;
    [SerializeField] private float jumpPower = 4;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;
    [SerializeField] private Text scoreMenu;

    void Start()
    {
        scoreCanvas.SetActive(true);
        deathMenu.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            highscoreText.text = ((int)highscore).ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            isJumping = true;
        }
        else 
        {
            isJumping = false;
        }
        
    }
    private void FixedUpdate() 
    {
        Jump();
    }

    private void Jump()
    {
        if (isJumping)
        {
            rb.velocity = new Vector2(0, jumpPower);
            anim.SetBool("isJumping", true);
        }
        else if (!isJumping)
        {
            anim.SetBool("isJumping", false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Border") || collision.tag.Equals("Pipe"))
        {
            scoreCanvas.SetActive(false);
            scoreMenu.text = ((int)score).ToString();

            isHighscore();
            
            deathMenu.SetActive(true);
            Destroy(this.gameObject);
        }
        else if (collision.tag.Equals("Score"))
        {
            score++;
            scoreText.text = ((int)score).ToString();  
        }
    }

    private void isHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = ((int)highscore).ToString();
            PlayerPrefs.SetInt("highscore", (int)highscore);
        }
    }
}
