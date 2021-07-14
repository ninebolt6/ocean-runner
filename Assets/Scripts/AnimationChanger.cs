using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    private GroundCheck ground;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponentInChildren<GroundCheck>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Ground", ground.isGrounded);
    }
}
