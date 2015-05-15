using UnityEngine;
using System.Collections;

public class CheckCation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            Shout.canThrow = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            Shout.canThrow = false;
        }
    }
}
