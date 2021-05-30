using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
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
        if(grounded)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                grounded = false;
                rb.AddForce(Vector2.up * JumpPower);
                Debug.Log("Jump!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("Grounded!");
        }
    }
}
