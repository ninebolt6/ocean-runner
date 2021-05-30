using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded;
    public float JumpPower;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.right * MoveSpeed);
        if(grounded) {
            if(Input.GetKeyDown(KeyCode.W))
            {
                grounded = false;
                rb.AddForce(Vector3.up * JumpPower);
                Debug.Log("Jump!");
            }
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("Grounded!");
        }
    }
}
