using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public AudioClip door_OpenSound;

    public AudioClip door_CloseSound;

    private bool isOpen = false;

    private float openTimeLimite = 3.0f;

    private float openTime = 0.0f;

    AudioSource audio;
    

    Animation animate;

    void Start() {
        audio = GetComponent<AudioSource>();
        animate = gameObject.transform.parent.GetComponent<Animation>();
    }


    void Update(){
        if (isOpen) {
            if (openTime > openTimeLimite){
                Close();
            }
            else {
                openTime += Time.deltaTime;
            }
            
        }
    }

    void Open(){
        if (isOpen) {
            return;
        }
        isOpen = true;
        
        audio.PlayOneShot(door_OpenSound);
        animate.Play("openDoor");
    }

    void Close() {
        isOpen = false;
        audio.PlayOneShot(door_CloseSound);
        animate.Play("closeDoor");
        openTime = 0.0f;
    }

}
