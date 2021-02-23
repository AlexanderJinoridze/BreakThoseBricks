using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {
    NotStarted,
    Playing,
    Completed,
    Failed
}

[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour
{
    public AudioClip StartSound;
    public AudioClip FailedSound;

    private GameState currentState = GameState.NotStarted;

    private Brick[] allBricks;
    private Ball[] allBalls;
    private Paddle paddle;

    public float Timer = 0.0f;
    private int minutes;
    private int seconds;
    public string formattedTime;


    private Text feedback;
    public Text text;

    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject buttonBackground;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];
        allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];

        paddle = GameObject.FindObjectOfType<Paddle>();

        print("Bricks:" + allBricks.Length);
        print("Balls:" + allBalls.Length);
        print("Paddle" + paddle);

        ChangeText("Click To Begin");

        SwitchState(GameState.NotStarted);


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.NotStarted:
                ChangeText("Click To Begin");
                if (Input.GetMouseButtonDown(0))
                {
                    SwitchState(GameState.Playing);
                }
                break;
            case GameState.Playing:
                {
                    Timer += Time.deltaTime;
                    minutes = Mathf.FloorToInt(Timer / 60F);
                    seconds = Mathf.FloorToInt(Timer - minutes * 60);
                    formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

                    ChangeText("Time: "+formattedTime);
                    bool allBlocksDestroyed = false;

                    if (FindObjectOfType(typeof(Ball)) == null)
                        SwitchState(GameState.Failed);

                    if (allBlocksDestroyed)
                        SwitchState(GameState.Completed);
                }
                break;
            case GameState.Failed:
                print("Gamestate Failed!");
                ChangeText("You Lose :(");
                break;
            case GameState.Completed:
                //bool allBlocksDestroyedFinal = false;

                Ball[] others = FindObjectsOfType(typeof(Ball)) as Ball[];

                foreach(Ball other in others)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
    }

    public void EnableButtons () {
        //Enable buttons for when the player loses
        restartButton.SetActive (true);
        mainMenuButton.SetActive (true);
        buttonBackground.SetActive (true);
    }

    public void ChangeText (string text) {
        GameObject canvas = GameObject.Find("Canvas");
        Text[] textValue = canvas.GetComponentsInChildren<Text>();
        textValue[0].text = text;
    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            default:
            case GameState.NotStarted:
                break;

            case GameState.Playing:
                GetComponent<AudioSource>().PlayOneShot(StartSound);
                break;
            case GameState.Completed:
                GetComponent<AudioSource>().PlayOneShot(StartSound);
                break;
            case GameState.Failed:
                GetComponent<AudioSource>().PlayOneShot(FailedSound);
                break;
        }
    }
}
