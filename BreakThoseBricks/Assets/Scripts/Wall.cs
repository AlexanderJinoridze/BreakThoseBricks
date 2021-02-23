using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Wall : MonoBehaviour
{
    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        print ("Ouch you hit my wall!");
        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}
