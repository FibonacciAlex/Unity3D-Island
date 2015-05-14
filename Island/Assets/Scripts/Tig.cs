using UnityEngine;
using System.Collections;

public class Tig : MonoBehaviour {

    public static int cellCount = 0;

    public Texture2D[] cellSrc;

    public Light doorLight;

    public Renderer cellRender;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (cellCount == 4)
        {
            doorLight.color = Color.green;
        }
        if (cellCount <= 4)
        {
            cellRender.material.mainTexture = cellSrc[cellCount];
        }
        else 
        {
            cellRender.material.mainTexture = cellSrc[4];
        }
        

	}

    //触发开门
    void OnTriggerEnter(Collider col) {
        
        if (col.gameObject.tag == "Player")
        {
            if (cellCount == 4)
            {
                transform.FindChild("door").SendMessage("Open");
            }
            else
            {
                transform.FindChild("door").SendMessage("PlayDoorLockSound");
            }
            
        
        }
        
    }

    public static void IncreaseCellCount() {
        cellCount++;
    }
}
