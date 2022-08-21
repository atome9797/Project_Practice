using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private Vector3 moveForce;
    public float gravity = -20f;
    private GameObject radio = null;

    private CharacterController characterController2;

    private void Awake()
    {
        characterController2 = GetComponent<CharacterController>();
    }

    private void Update()
    {
        radio = GameObject.FindWithTag("Radio");
        //���� ��ü�� Ȱ��ȭ ���̸�
        if (radio == null || radio.activeSelf == false)
        {

            if (!characterController2.isGrounded)
            {
                moveForce.y += gravity * Time.deltaTime;
            }

            characterController2.Move(moveForce * Time.deltaTime);
               
        }
    }

}
