using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public bool canDoubleJump = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "DownGround")
        {
            isGrounded = true;
            canDoubleJump = true;
            Debug.Log("Grounded!");
        }
    }
}
