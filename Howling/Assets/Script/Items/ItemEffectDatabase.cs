using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{

    public string itemName; //�������� �̸�(key ������ ����Ұ�)

    [Tooltip("HP�� �����մϴ�.")]
    public string[] part; //ȿ�� ��� �κ��� ȸ���ϰų� Ȥ�� ���� ��������. ���� �ϳ��� ��ġ�� ȿ���� �������� �� �־� �迭
    public int[] num; //��ġ.���� �ϳ��� ��ġ�� ȿ���� ������ �ϼ� �־� �迭. �׿� ���� ��ġ

}

public class ItemEffectDatabase : MonoBehaviour
{

    [SerializeField]
    private ItemEffect[] itemEffects;

    private const string HP = "HP";

    [SerializeField]
    private StatusController thePlayerStatus;

    [SerializeField]
    private WeaponManager theWeaponManager;
   
    [SerializeField]
    private SlotToolTip theSlotToolTip;

    public void UseItem(Item _item)
    {
        if(_item.itemType == Item.ItemType.Equipment)
        {
            StartCoroutine(theWeaponManager.ChangeWeaponCoroutine(_item.weaponType, _item.itemName));
        }

        if(_item.itemType == Item.ItemType.Used)
        {
            for(int i = 0; i < itemEffects.Length; i++)
            {
                if(itemEffects[i].itemName == _item.itemName)
                {
                    for(int j =0; j < itemEffects[i].part.Length; j++)
                    {
                        switch(itemEffects[i].part[j])
                        {
                            case HP:
                                thePlayerStatus.IncreaseHP(itemEffects[i].num[j]);
                                break;
                            default:
                                Debug.Log("�߸��� Status ����. HP�� �����մϴ�.");
                                break;
                        }
                        Debug.Log(_item.itemName + " �� ����߽��ϴ�.");
                    }
                    
                    return;
                }
            }
            Debug.Log("itemEffectDatabase�� ��ġ�ϴ� itemName�� �����ϴ�.");
        }
    }

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

}
