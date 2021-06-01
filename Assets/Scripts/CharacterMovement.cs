using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    private bool canDoubleJump;
    public float JumpPower;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {    
        rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * JumpPower);
                Debug.Log("Jump!");
            }
            else if(canDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, (JumpPower/50));
                //rb.AddForce(Vector2.up * JumpPower);
                Debug.Log("Double Jump!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
            canDoubleJump = true;
            Debug.Log("Grounded!");
        }
    }
}
