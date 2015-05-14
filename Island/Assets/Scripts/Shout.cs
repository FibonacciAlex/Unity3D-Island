using UnityEngine;
using System.Collections;

public class Shout : MonoBehaviour {


    public Rigidbody coconutBullet;

    AudioSource soundPlayer;
	// Use this for initialization
	void Start () {
        soundPlayer = GetComponent<AudioSource>();
	}

    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            soundPlayer.Play();
            Rigidbody bullet = Instantiate(coconutBullet, transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = transform.forward * 30;
            Destroy(bullet, 1.0f);
        }
	}

}
