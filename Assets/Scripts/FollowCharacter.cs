using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCharacter : MonoBehaviour
{
    private GameObject character;
    private Transform charTransform;

    public float yMargin = 0.8f;
    public float ySmooth = 10f;

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

    private bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - charTransform.position.y) > yMargin;
    }

    void MoveCamera()
    {
        float targetY = transform.position.y;

        if(CheckYMargin())
        {
            Debug.Log("true!" + Time.deltaTime);
            targetY = Mathf.Lerp(transform.position.y, charTransform.position.y, ySmooth*Time.deltaTime);
        }

        transform.position = new Vector3(charTransform.position.x, targetY, transform.position.z);
    }


}
