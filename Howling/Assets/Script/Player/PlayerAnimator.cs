using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayerMoveAnimation(float x, float y)
    {
        _animator.SetFloat(PlayerAnimID.MoveForward, x + y);
        _animator.SetFloat(PlayerAnimID.MoveBack, x + y);
    }


    public void PickUp(bool isCheck)
    {
        _animator.SetBool(PlayerAnimID.Pick, isCheck);
    }
}
