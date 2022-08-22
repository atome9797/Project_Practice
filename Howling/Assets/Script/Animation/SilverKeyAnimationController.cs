using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverKeyAnimationController : MonoBehaviour
{
    [SerializeField]
    private float range = 10f; //�ִϸ��̼� ���� ������ �ִ� �Ÿ�

    private bool pickActivated = false; //�ִϸ��̼� ���� �����ҽ� true

    private RaycastHit hitInfo; //�浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask; //Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ���� �Ҽ� �־�� �Ѵ�.

    [SerializeField]
    private Text actionText; //�ൿ�� ���� �� �ؽ�Ʈ

    private bool isOpenDoor = false;

    public Animator _animator;

    private GameObject key = null;


    private void Update()
    {
        key = GameObject.FindWithTag("SilverKey");
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckItem();
            CanPickUp();
        }
    }


    private void CheckItem()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            
            if (hitInfo.transform.tag == "SilverKeyDoor")
            {
                ItemInfoAppear();
            }
        }
        else
        {
            ItemInfoDisappear();
        }
    }


    private void ItemInfoAppear()
    {
        pickActivated = true;
       /* actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemDesc + " (��Ŭ��)</color>";*/
    }


    private void ItemInfoDisappear()
    {
        pickActivated = false;
        //actionText.gameObject.SetActive(false);
    }


    private void CanPickUp()
    {
        if (pickActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log("������Ʈ ��ü : " + hitInfo);

                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " �ִϸ��̼��� ����Ǿ����ϴ�.");//�κ��丮 �ֱ�

                isOpenDoor = !isOpenDoor;
                //���϶� ������ �ִϸ��̼� ����
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "SilverDoor")
                {
                    if (key != null)
                    {
                        if (key.activeSelf == true)
                        {
                            GameObject hitObject = hitInfo.transform.gameObject;
                            _animator = hitObject.GetComponent<Animator>();
                            _animator.SetBool(PlayerAnimID.OpenDoor, isOpenDoor);
                        }
                    }
                }

                ItemInfoDisappear();
            }
        }
    }

}
