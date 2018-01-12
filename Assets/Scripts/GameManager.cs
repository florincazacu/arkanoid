using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject ball;
    public GameObject racket;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public Text gameWonText;
    private int score = 0;
    private int lives = 5;
    private bool gameStarted = false;

    public Transform redBrick;
    public Transform yellowBrick;
    public Transform blueBrick;
    public Transform purpleBrick;
    public Transform greenBrick;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame() {
        gameOverText.enabled = false;
        gameWonText.enabled = false;
        scoreText.text = "SCORE: " + score.ToString();
        livesText.text = "LIVES: " + lives.ToString();
        addBrick(redBrick, 90);
        addBrick(yellowBrick, 82);
        addBrick(blueBrick, 74);
        addBrick(purpleBrick, 66);
        addBrick(greenBrick, 58);
    }

    public void addBrick(Transform brickColor, int posY) {
        for (int posX = -96; posX <= 96; posX += 16) {
            GameObject gameObject = Instantiate(brickColor, new Vector2(posX, posY), Quaternion.identity).gameObject;
            gameObject.name = brickColor.name;
        }
    }

    public void brickHit(string blockobjectHit) {
        switch (blockobjectHit) {
            case "greenBrick":
                score += 5;
                break;
            case "purpleBrick":
                score += 10;
                break;
            case "blueBrick":
                score += 15;
                break;
            case "yellowBrick":
                score += 20;
                break;
            case "redBrick":
                score += 25;
                break;
        }
        UpdateScore();
    }

    public void UpdateScore() {
        scoreText.text = "SCORE:" + score.ToString();
    }

    public void UpdateLives() {
        livesText.text = "LIVES:" + lives.ToString();
    }

    void ballOut() {
        lives -= 1;
        UpdateLives();
        ball.SendMessage("resetBall");
        racket.SendMessage("resetRacket");
    }

    public void gameOver() {
        gameOverText.enabled = true;
    }

    public void gameWon() {
        if (GameObject.Find("redBrick") == null && GameObject.Find("yellowBrick") == null && GameObject.Find("blueBrick") == null && GameObject.Find("purpleBrick") == null && GameObject.Find("greenBrick") == null) {
            gameWonText.enabled = true;
            ball.SendMessage("resetBall");
        }
    }

    // Update is called once per frame
    void Update () {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) {
            gameStarted = true;
            ball.SendMessage("launchBall");
        }
        if (ball.transform.position.y < -105) {
            ballOut();
            gameStarted = false;
        }
    }
}
