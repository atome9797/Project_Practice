using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float RoationSpeed = 60f;
    
    private PlayerInput _input;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private RotateToMouse _rotateToMouse;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rotateToMouse = GetComponent<RotateToMouse>();
    }

    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        move();
        rotate();
        updateMouseRotate();
        
        _animator.SetFloat(PlayerAnimID.MoveForward, _input.X);
        _animator.SetFloat(PlayerAnimID.MoveBack, _input.X);
    }


    private void updateMouseRotate()
    {
        _rotateToMouse.UpdateRotate(_input.mouseX, _input.mouseY);
    }


    private void move()
    {
        Vector3 deltaPosition = moveSpeed * _input.X * Time.fixedDeltaTime * transform.forward;
        Vector3 newPositin = _rigidbody.position + deltaPosition;
        _rigidbody.MovePosition(newPositin);
    }


    private void rotate()
    {
        float rotateDirection = _input.Y;

        if (rotateDirection != 0f)
        {
            float rotationAmount = rotateDirection * RoationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
    }


}
