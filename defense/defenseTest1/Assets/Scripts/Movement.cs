using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float jumpForce = 3.0f;
    private float gravity = -9.81f;

    private Vector3 direction;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            direction.y+=gravity*Time.deltaTime;
        }

        characterController.Move(direction*moveSpeed*Time.deltaTime);
    }

    public void MoveTo(Vector3 dir)
    {
        Vector3 tempDir=dir.normalized;
        direction= new Vector3(tempDir.x,direction.y,tempDir.z);
    }

    public void JumpTo()
    {
        if(characterController.isGrounded == true)
        {
            direction.y = jumpForce;
        }
    }
}
