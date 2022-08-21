using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private RotateToMouse _rotateToMouse;
    private PlayerMovement movement;
    private Status status;
    private AudioSource audioSource;
    private PlayerInput _input;
    private PlayerAnimator _animator;
    public GameObject _player;
    public GameObject _eye;
    private bool sitDown = false; 
    private bool prestate = false;
    private GameObject radio = null;
    [SerializeField]
    private WeaponManager theWeaponManager;
    [SerializeField]
    private ActionController thePlayer;
    public Item item; //���� �ӽ�


    private void Awake()
    {
        //���콺 Ŀ�� ������ �ʰ� ����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<PlayerMovement>();
        status = GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<PlayerAnimator>();
    }


    private void Update()
    {
        if (_input.CanPickup)
        {
            //�ڸ�ƾ �̿��ؼ� 1�ʵ��� �ִϸ��̼� �����Ű��
            StartCoroutine(GrapEffect());
        }

        UpdateMove();
        UpdateJump();
        StartCoroutine(CoroutineDown());
        UpdateRotate();
        
        if(!Inventory.inventoryActivated)
        {
            mouseOff();
            Dropdown();
        }
        else
        {
            mouseOn();
        }
    }


    private void Dropdown()
    {
        //��Ŭ�� ��������
        if (Input.GetMouseButtonDown(1))
        {
            radio = GameObject.FindWithTag("Radio");
            if (radio != null)
            {
                //���� ��ü�� Ȱ��ȭ ���̸�
                if (radio.activeSelf == true)
                {
                   
                   StartCoroutine(theWeaponManager.ChangeWeaponCoroutine("HAND", "HAND"));
                   Instantiate(item.itemPrefab, thePlayer.transform.position + thePlayer.transform.forward, Quaternion.identity);
                }
            }
             
        }
    }




    IEnumerator CoroutineDown()
    {
        UpdateDownStepMoveAnimation(_input.CanSitDown);
        if (!_input.CanSitDown)
        {
            UpdateMoveAnimation();
            sitDown = false;
        }
        else
        {
            sitDown = true;
        }

        //���� ���¿� �ٸ��� ��ȭ�ֱ�
        if(prestate != sitDown)
        {
            if(sitDown)
            {
                _player.transform.Translate(new Vector3(0f, -0.5f, 0f));
                _eye.transform.Translate(new Vector3(0f, -0.2f, 0f));
            }else
            {
                _player.transform.Translate(new Vector3(0f, 0.5f, 0f));
                _eye.transform.Translate(new Vector3(0f, 0.2f, 0f));
            }
        }

        prestate = sitDown;

        yield break;
    }


    private void mouseOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void mouseOff()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
    
    private void UpdateDownStepMoveAnimation(bool isDownStep)
    {
        _animator.PlayerSitDownMoveAnimation(isDownStep);
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
