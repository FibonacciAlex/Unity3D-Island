using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {
    public AudioClip pickUpSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,100*Time.deltaTime,0);

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //销毁物体 增加收集数
            col.gameObject.SendMessage("PickUpCell");
            AudioSource.PlayClipAtPoint(pickUpSound,transform.position);
            Destroy(gameObject);
        }
    }
}
