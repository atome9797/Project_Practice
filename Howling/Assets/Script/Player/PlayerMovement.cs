using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    private Vector3 moveForce;

    public float jumpForce = 5f;
    public float gravity = -20f;
    


    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(!characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveForce * Time.deltaTime);
    }



    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if(characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }





}
