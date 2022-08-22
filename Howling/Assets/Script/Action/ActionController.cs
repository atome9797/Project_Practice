using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range = 10f; //������ ������ ������ �ִ� �Ÿ�

    private bool pickActivated = false; //������ ���� �����ҽ� true

    private RaycastHit hitInfo; //�浹ü ���� ����
    
    [SerializeField]
    private LayerMask layerMask; //Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ���� �Ҽ� �־�� �Ѵ�.

    [SerializeField]
    private Text actionText; //�ൿ�� ���� �� �ؽ�Ʈ

    //������ ó��
    [SerializeField]
    private Inventory theInventory;

    [SerializeField]
    private GameObject go_Record; // Inventory_Base �̹���

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
                if (Input.GetKeyDown(KeyCode.U)) //�÷��� ��ư U
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
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� (��Ŭ��)</color>";
    }

    private void ItemInfoAppear2()
    {
        pickActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� (��Ŭ��) ���� ��� (U) </color>";
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�.");//�κ��丮 �ֱ�

                //������ ȹ�� ó�� (������ ������ �κ��丮 ���Կ� ������Ʈ �Ѵ�.)
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }


}
