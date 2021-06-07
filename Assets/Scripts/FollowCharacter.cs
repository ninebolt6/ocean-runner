using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCharacter : MonoBehaviour
{
    private GameObject character;
    private Transform charTransform;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character2D");
        charTransform = character.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = new Vector3(charTransform.position.x, transform.position.y, transform.position.z);
    }

    
}
