using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverKeyAnimationController : MonoBehaviour
{
    [SerializeField]
    private float range = 10f; //애니메이션 실행 가능한 최대 거리

    private bool pickActivated = false; //애니메이션 실행 가능할시 true

    private RaycastHit hitInfo; //충돌체 정보 저장

    [SerializeField]
    private LayerMask layerMask; //특정 레이어를 가진 오브젝트에 대해서만 습득 할수 있어야 한다.

    [SerializeField]
    private Text actionText; //행동을 보여 줄 텍스트

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
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemDesc + " (왼클릭)</color>";*/
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
                Debug.Log("오브젝트 객체 : " + hitInfo);

                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 애니메이션이 실행되었습니다.");//인벤토리 넣기

                isOpenDoor = !isOpenDoor;
                //문일때 열리는 애니메이션 실행
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
