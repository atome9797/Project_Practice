using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private RotateToMouse _rotateToMouse;
    private PlayerMovement movement;
    private Status status;
    private AudioSource audioSource;
    private PlayerInput _input;
    private PlayerAnimator _animator;

    private void Awake()
    {
        //���콺 Ŀ�� ������ �ʰ� ����
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        _rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<PlayerMovement>();
        status = GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<PlayerAnimator>();
    }


    private void Update()
    {
        if(!Inventory.inventoryActivated)
        {
            UpdateRotate();
            UpdateMove();
            UpdateJump();
            UpdateMoveAnimation();

            if (_input.CanPickup)
            {
                //�ڸ�ƾ �̿��ؼ� 1�ʵ��� �ִϸ��̼� �����Ű��
                StartCoroutine(GrapEffect());
            }
        }
    }

    private IEnumerator GrapEffect()
    {
        _animator.PickUp(true);

        // 0.03�� ���� ��� ó���� ���
        yield return new WaitForSeconds(1f);

        _animator.PickUp(false);
    }

    private void UpdateMoveAnimation()
    {
        _animator.PlayerMoveAnimation(_input.X, _input.Y);
    }

    private void UpdateRotate()
    {
        _rotateToMouse.UpdateRotate(_input.mouseX, _input.mouseY);
    }

    private void UpdateMove()
    {
        movement.MoveTo(new Vector3(_input.Y, 0, _input.X));
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }
    }
    



}
