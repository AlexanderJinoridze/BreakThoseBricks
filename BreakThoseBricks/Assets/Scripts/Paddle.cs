using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour
{
    public int i = 0;

    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        print("This is my first Unity script, yay!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
        float mousePos = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePos, .5f, 15.5f);
        this.transform.position = paddlePos;
    }

    //OnCollisionEnter will only be called when one of the colliders has a rigidbody
    void OnCollisionEnter2D(Collision2D c)
    {
        //Change the sound pitch if a slowdown powerup has been picked up
        GetComponent<AudioSource>().pitch = Time.timeScale;
        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}