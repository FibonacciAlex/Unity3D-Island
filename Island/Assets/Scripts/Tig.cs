using UnityEngine;
using System.Collections;

public class Tig : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //触发开门
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player" && PlayerCollsion.cellCount == 4) {
            
            transform.FindChild("door").SendMessage("Open");
            
        }
    }
}
