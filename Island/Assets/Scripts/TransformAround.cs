using UnityEngine;
using System.Collections;

public class TransformAround : MonoBehaviour {


    public float speed = 0.001f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 point = new Vector3(334, 32, 140);
        transform.RotateAround(point, Vector3.forward, speed * Time.deltaTime);
	}

}
