using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int speed =5;
    private float horizontalMovement;
    private float xRange=8.35f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lives;

    public GameObject bulletPf;
    private int score;
    public bool isGamestarted=false;
    public GameObject titleScreen;
    public GameObject MenuScreen;

    public GameObject PauseButton;
    public GameObject ResumeButton;


    // Start is called before the first frame update
    void Start()
    {
    }
    //when menu button is clickedclose the the tilesscreen button
    public void OnMenuClicked()
    {
        MenuScreen.SetActive(true);
        titleScreen.SetActive(false);

    }
 public void OnBackButtonClicked()
    {
        MenuScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    //for starting the game when the play button is pressed
    public void GameStart()
    {

       
        score = 0;
        isGamestarted = true;
        scoreText.gameObject.SetActive(true);
        lives.gameObject.SetActive(true);
        titleScreen.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);

    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
    }


    public void UpdateScores(int Scorestoadd)
    {
        score += Scorestoadd;
        scoreText.text = "Scores : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        BulletSpawner(); //for spawning bullets in front of player
    }

    private void BulletSpawner()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGamestarted)
        {
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y +0.65f);
            //Launch projectile from player
            Instantiate(bulletPf,playerPosition , bulletPf.transform.rotation);

        }
    }

    private void PlayerMovement()
    {
    if (isGamestarted)
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalMovement);
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }
    }
}
