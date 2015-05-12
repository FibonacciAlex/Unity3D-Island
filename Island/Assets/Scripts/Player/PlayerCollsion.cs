using UnityEngine;
using System.Collections;

public class PlayerCollsion : MonoBehaviour
{
    public static int cellCount = 0;
    void Update()
    {
        

    }

    //碰撞开门
    /*void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.tag == "PlayerDoor") { 
            //执行开门操作
            hit.gameObject.SendMessage("Open");
        }
    }*/


    void PickUpCell() {
        cellCount++;
    }
}
