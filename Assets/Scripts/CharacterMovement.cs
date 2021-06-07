using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded = false;
    private bool canDoubleJump = false;
    private bool canDown = false;
    private Collider2D downCollision;
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
        if(Input.GetKeyDown(KeyCode.S))
        {
            // もしも すり抜け可能フラッグがtrueだったら
            if(canDown)
            {
                // すり抜ける処理
                if(downCollision != null)
                {
                    downCollision.enabled = false;
                    downCollision = null;
                }
                canDown = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ground" || collisionInfo.gameObject.tag == "DownGround")
        {
            grounded = true;
            canDoubleJump = true;
            Debug.Log("Grounded!");
        }

        // もしも「すり抜けられるタグ」が付いたコリジョンに入ったら
        if(collisionInfo.gameObject.tag == "DownGround")
        {
            // すり抜け可能フラッグをtrueに
            canDown = true;
            downCollision = collisionInfo.collider;
        }
    }

    // もしも「すり抜けられるタグ」が付いたコリジョンから出たら
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "DownGround")
        {
            // すり抜け可能フラッグをfalseに
            canDown = false;
        }
    }
}
