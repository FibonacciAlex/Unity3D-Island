using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public AudioClip door_OpenSound;

    public AudioClip door_CloseSound;

    private bool isOpen = false;

    private float openTimeLimite = 3.0f;

    private float openTime = 0.0f;

    AudioSource audioPlayer;
    

    Animation animate;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
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

        audioPlayer.PlayOneShot(door_OpenSound);
        animate.Play("OpenDoor");
    }

    void Close() {
        isOpen = false;
        audioPlayer.PlayOneShot(door_CloseSound);
        animate.Play("CloseDoor");
        openTime = 0.0f;
    }

    void PlayDoorLockSound() {
        audioPlayer.Play();
    }

    


}
