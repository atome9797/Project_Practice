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

    
    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if(Input.GetMouseButton(0))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
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
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� (��Ŭ��)</color>";
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
