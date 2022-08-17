using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent; //Slot들의 부모인 Grid Setting

    private Slot[] slots;//슬롯들 배열

    private void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }


    private void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if(inventoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }


    public void AcquireItem(Item _item, int _count = 1)
    {
        //이미 획득한 아이템이면 +1 증가해줌
        if(Item.ItemType.Equipment != _item.itemType)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if(slots[i].item != null) //null이라면 slots[i].item.itemName 할때 런타임 에러남
                {
                    if(slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        //초기 아이템이면 새로 설정
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

}
