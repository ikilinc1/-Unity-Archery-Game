using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private float gameLengthInSeconds = 10f;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private GameObject gameStateUI;

    private float timer;
    private Text gameStateText;
    private Animator gameStateTextAnim;
    
    public static bool gameStarted = false;
    public static int score;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStateText = gameStateUI.GetComponent<Text>();
        gameStateText.text = "Hit Space to play!";

        gameStateTextAnim = gameStateUI.GetComponent<Animator>();
        gameStateTextAnim.SetBool("ShowText", true);

        timer = gameLengthInSeconds;
        
        UpdateScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (gameStarted)
        {
            timer -= Time.deltaTime;
            UpdateScoreBoard();
        }

        if (gameStarted && timer<=0 )
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void StartGame()
    {
        score = 0;
        gameStarted = true;
        gameStateTextAnim.SetBool("ShowText", false);
    }

    private void EndGame()
    {
        gameStateText.text = "Game Over!\nPress Space to restart";
        gameStateTextAnim.SetBool("ShowText", true);
        gameStarted = false;
        timer = gameLengthInSeconds;
    }

    private void UpdateScoreBoard()
    {
        scoreText.text = score + " Targets";
        timerText.text = Mathf.RoundToInt(timer) + " Seconds";
    }
}
