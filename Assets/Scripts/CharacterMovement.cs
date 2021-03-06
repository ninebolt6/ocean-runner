using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float JumpPower;
    public float MoveSpeed;
    public AudioClip jump_sound;

    private Rigidbody2D rb;
    private GroundCheck ground;
    private bool canDown = false;
    private Collider2D downCollision;
    [SerializeField]
    private AudioSource audio_source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        // standard movement
        rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);

        // jump
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(Time.timeScale != 0.0f)
            {
                if(ground.isGrounded)
                {
                    ground.isGrounded = false;
                    rb.AddForce(Vector2.up * JumpPower);
                    audio_source.PlayOneShot(jump_sound);
                    Debug.Log("Jump!");
                }
                else if(ground.canDoubleJump)
                {
                    ground.canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, (JumpPower/50));
                    audio_source.PlayOneShot(jump_sound);
                    //rb.AddForce(Vector2.up * JumpPower);
                    Debug.Log("Double Jump!");
                }
            }
        }

        if(canDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 10f);
        }

        // すり抜ける床判定
        // もしも キーボードのS が押されたら
        // if(Input.GetKeyDown(KeyCode.S))
        // {
        //     // もしも すり抜け可能フラッグがtrueだったら
        //     if(canDown)
        //     {
        //         // すり抜ける処理
        //         if(downCollision != null)
        //         {
        //             downCollision.enabled = false;
        //             downCollision = null;
        //         }
        //         canDown = false;
        //     }
        // }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // もしも「すり抜けられるタグ」が付いたコリジョンに入ったら
        // if(collisionInfo.gameObject.tag == "DownGround")
        // {
        //     // すり抜け可能フラッグをtrueに
        //     canDown = true;
        //     downCollision = collisionInfo.collider;
        // }
    }

    // もしも「すり抜けられるタグ」が付いたコリジョンから出たら
    // void OnCollisionExit2D(Collision2D collisionInfo)
    // {
    //     if(collisionInfo.gameObject.tag == "DownGround")
    //     {
    //         // すり抜け可能フラッグをfalseに
    //         canDown = false;
    //     }
    // }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "DownGround")
        {
            rb.AddForce(new Vector2(0, -20f));
            Debug.Log("DOWN!");
        }
    }
}
