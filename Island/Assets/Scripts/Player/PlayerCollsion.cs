using UnityEngine;
using System.Collections;

public class PlayerCollsion : MonoBehaviour
{

    private bool door_IsOpen = false;

    private float door_Time = 0.0f;

    private GameObject current_Door;

    float door_OpenTime = 3.0f;
    RaycastHit rayHit;
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out rayHit, 3.0f))
        {
            print("----------");
            if (rayHit.collider.gameObject.tag == "PlayerDoor")
            {
                print("===============");
                rayHit.collider.gameObject.SendMessage("open");
            }
        }

    }


  /*  void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.tag == "PlayerDoor" && door_IsOpen == false) { 
            //执行开门操作
            hit.gameObject.SendMessage("Open");
        }
    }*/

}
