using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    private Vector3 moveForce;
    public float gravity = -20f;
    private GameObject key = null;

    private CharacterController characterController2;

    private void Awake()
    {
        characterController2 = GetComponent<CharacterController>();
    }

    private void Update()
    {
        key = GameObject.FindWithTag("GoldKey");
        //���� ��ü�� Ȱ��ȭ ���̸�
        if (key == null || key.activeSelf == false)
        {

            if (!characterController2.isGrounded)
            {
                moveForce.y += gravity * Time.deltaTime;
            }

            characterController2.Move(moveForce * Time.deltaTime);

            transform.Rotate(0, 0.2f, 0);

        }
    }
}
