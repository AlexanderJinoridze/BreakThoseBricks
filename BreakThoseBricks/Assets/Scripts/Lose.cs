using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private Ball ball;
    private GameManager gameManager;
    public GameObject[] players;
    public GameObject[] extras;

    IEnumerator Pause() {
        print("Before Waiting 2 seconds");

        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.SwitchState(GameState.Failed);

        gameManager.EnableButtons();

        yield return new WaitForSeconds(2);

        //ball = GameObject.FindObjectOfType<Ball>();
        //ball.gameStarted = false;

        //Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.loadedScene);

        print("After Waiting 2 seconds");
    }

    void OnTriggerEnter2D (Collider2D trigger) {
        if(trigger.name == "Ball"){
            print("Lost Triggered!");
            StartCoroutine(Pause());
        }
    }
}
