using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D),typeof(AudioSource))]
public class BasePowerUp : MonoBehaviour
{
    public float DropSpeed = 1;
    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Paddle"){
            OnPickup();

            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;

            GetComponent<AudioSource>().pitch = Time.timeScale;
            GetComponent<AudioSource>().PlayOneShot(Sound);

            yield return new WaitForSeconds(Sound.length);
        }
    }

    protected virtual void OnPickup(){
        
    }
}
