using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject quitButton;

    public void LoadScene (int level)
    {
        Application.LoadLevel(level);
    }

    public void QuitGame(){
        if (Application.isEditor) {
            Debug.Log ("Attempted to quit from the Editor.");
        } else if (Application.platform == RuntimePlatform.WebGLPlayer) {
            quitButton = GameObject.FindGameObjectWithTag ("Quit");
            quitButton.SetActive (false);
            Debug.Log ("Attempted to quit from the WebGL Player.");
        }
        else {
            Application.Quit();
        }
    }
}