using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public bool canDoubleJump = false;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground" || collisionInfo.gameObject.tag == "DownGround")
        {
            isGrounded = true;
            canDoubleJump = true;
            Debug.Log("Grounded!");
        }
    }
}
