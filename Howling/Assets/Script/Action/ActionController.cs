using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range = 10f; //아이템 습득이 가능한 최대 거리

    private bool pickActivated = false; //아이템 습득 가능할시 true

    private RaycastHit hitInfo; //충돌체 정보 저장
    
    [SerializeField]
    private LayerMask layerMask; //특정 레이어를 가진 오브젝트에 대해서만 습득 할수 있어야 한다.

    [SerializeField]
    private Text actionText; //행동을 보여 줄 텍스트

    //아이템 처리
    [SerializeField]
    private Inventory theInventory;

    [SerializeField]
    private GameObject go_Record; // Inventory_Base 이미지

    public static bool RecordActivated = false;


    private void Update()
    {
        CheckItem();
        TryAction();

        if (Input.GetKeyDown(KeyCode.P) && RecordActivated)
        {
            ScaleFromMicrophone.PlaySnd();
        }
        else if (Input.GetKeyDown(KeyCode.R) && RecordActivated)
        {
            ScaleFromMicrophone.RecSnd();
        }
    }

    private void TryAction()
    {
        if(Input.GetMouseButton(0) && !RecordActivated)
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void OpenRecord()
    {
        go_Record.SetActive(true);
    }

    private void CloseRecord()
    {
        go_Record.SetActive(false);
    }

    

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            
            if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Radio") 
            {
                ItemInfoAppear2();
                if (Input.GetKeyDown(KeyCode.U)) //플레이 버튼 U
                {
                    RecordActivated = !RecordActivated;

                    if(RecordActivated)
                    {
                        OpenRecord();
                    }
                    else
                    {
                        CloseRecord();
                    }
                }
            }
            else if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
                CloseRecord();
            }
        }
        else
        {
            ItemInfoDisappear();
            CloseRecord();
        }
    }


    private void ItemInfoAppear()
    {
        pickActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 (왼클릭)</color>";
    }

    private void ItemInfoAppear2()
    {
        pickActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 (왼클릭) 라디오 사용 (U) </color>";
    }

    private void ItemInfoDisappear()
    {
        pickActivated = false;
        actionText.gameObject.SetActive(false); 
    }


    private void CanPickUp()
    {
        if(pickActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다.");//인벤토리 넣기

                //아이템 획득 처리 (아이템 주으면 인벤토리 슬롯에 업데이트 한다.)
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }


}
