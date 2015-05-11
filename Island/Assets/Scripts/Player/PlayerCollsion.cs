using UnityEngine;
using System.Collections;

public class PlayerCollsion : MonoBehaviour
{

    void Update()
    {
        

    }


    void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.tag == "PlayerDoor") { 
            //执行开门操作
            hit.gameObject.SendMessage("Open");
        }
    }

}
