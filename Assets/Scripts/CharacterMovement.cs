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
        // standard movement
        rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);

        // jump
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

        // すり抜ける床判定

        // もしも キーボードのS が押されたら
            // もしも すり抜け可能フラッグがtrueだったら
            // すり抜ける処理
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
            canDoubleJump = true;
            Debug.Log("Grounded!");
        }

        // もしも「すり抜けられるタグ」が付いたコリジョンに入ったら
            // すり抜け可能フラッグをtrueに
    }

    // もしも「すり抜けられるタグ」が付いたコリジョンから出たら
        // すり抜け可能フラッグをfalseに
}
