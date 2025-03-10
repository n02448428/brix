using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball initialBall;
    public Ball ballPreFab;

    public Paddle paddle;

    public static bool startGame;
    public static bool gameStarted;
    public static bool endGame;

    public int count, currentLvl;

    public Text endScreen, endNote;

    private string lvl;

    GameObject[] walls;

    //public Wall wall1, wall2, wall3;

    // Start is called before the first frame update
    void Start()
    {
        currentLvl = SceneManager.GetActiveScene().buildIndex;
        endScreen.text = "";
        endGame = false;
        InitializeBall();
    }

    // Update is called once per frame
    void Update()
    {
        
        PreStartGame();

        BeatLevel();

        YouLose();

        if (endScreen.text != "")
        {
            if (Input.GetMouseButtonDown(0))
            {
                ResetGame();
            }
        }
    }

    void PreStartGame()
    {
        Vector3 paddlePos = paddle.gameObject.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + 1.0f, 0);

        if (Input.GetMouseButtonDown(0))
        {
            startGame = true;
        }

        if (!startGame)
        {
            initialBall.transform.position = ballPos;
        }
    }

    void BeatLevel()
    {
        //bricks = GameObject.FindGameObjectsWithTag("Brick");
        //count = bricks.Length;

        if (gameStarted && initialBall.bricks <= 0)
        {
            if (currentLvl <= 4)
            {
                endScreen.text = "Level "+currentLvl;
                nextLevel();
            }
            else
            {
                endScreen.text = "You Win !";

                if (currentLvl == 5)
                {
                    endNote = GameObject.Find("Text2").GetComponent<Text>();
                    endNote.text = "Hit 0 key on title screen for Bonus level.";
                    
                    //wall1 = GameObject.Find("Wall1");
                    //for (int  i = 0;  i < walls.Length;  i++)
                    //{
                    //   (Wall) walls[i].endGame = true;
                    //}
                }

                if (!endGame)
                {
                    endGame = true;
                    InvokeRepeating("EndGameParty", 0, 0.1f);
                }
            }
        }

    }

    void YouLose()
    {
        if(endScreen.text == "" && initialBall == null)
        {
            endScreen.text = "Try Again !";
            currentLvl = 1;
        }

    }

    void nextLevel()
    {
        endScreen.text = "";
        startGame = false;
        gameStarted = false;
        SceneManager.LoadSceneAsync("Level "+(currentLvl+1));
        InitializeBall();
    }

    void ResetGame()
    {
        currentLvl = 1;
        SceneManager.LoadSceneAsync("Title");
        startGame = false;
        gameStarted = false;
        endScreen.text = "";
        InitializeBall();
    }

    void InitializeBall()
    {
        Vector3 paddlePos = paddle.gameObject.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + 2.5f, 0);
        initialBall = Instantiate(ballPreFab, ballPos, Quaternion.identity);
    }

    void EndGameParty()
    {
        endScreen.color = new Color(Random.value, Random.value, Random.value);
        InitializeBall();
    }
}
