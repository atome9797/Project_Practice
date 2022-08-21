using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    //���콺 �巡�� �������� �߻��ϴ� �̺�Ʈ
    private Rect baseRect; //Inventory_Base �̹����� Rect ������ �޾ƿ�

    private ItemEffectDatabase theItemEffectDatabase;

    public Item item; //ȹ���� ������
    public int itemCount; //ȹ���� �������� ����
    public Image itemImage; //�������� �̹���

    [SerializeField]
    private Text text_Count; //������ ����
    [SerializeField]
    private GameObject go_CountImage; //������ �̹���

    private InputNumber theInputNumber;

    private void Start()
    {
        //FindObjectOfType ����� ���� : ���� ���� ������ ������ �������� SerializeField�ΰ͵��� �ڽ��� ��ü�� ���� �����ϱ� ������ None�� �Ǿ����
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();

        //Inventory_Base �� transform ���� �޾ƿ�
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;

        theInputNumber = FindObjectOfType<InputNumber>();
    }

    //������ �̹����� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //�κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage; //������ �̹����� sprite �� ����

        //���Ⱑ �ƴϸ�
        if(item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true); //������ �̹��� ���̰� ����
            text_Count.text = itemCount.ToString(); //������ 1�� ����
        }
        else //����� ������ ���� �Ⱥ��̰� ����
        {
            text_Count.text = "0"; //������ 0���� ����
            go_CountImage.SetActive(false); //������ �̹��� �Ⱥ��̰� ����
        }

        //������ ���·� �����ߴ� �̹��� ���̰� ����
        SetColor(1); 
    }

    //�ش� ������ ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if(itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //�ش� ���� ����
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    //���콺 Ŭ���ɶ� �߻��ϴ� �̺�Ʈ �Լ�
    public void OnPointerClick(PointerEventData eventData)
    {
        //��Ŭ�� ���� ���
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            //���Կ� �������� �������
            if(item != null)
            {
                theItemEffectDatabase.UseItem(item);
                
                SetSlotCount(-1);
                
            }
        }
    }


    //���콺 �巡�װ� ���������� �߻��ϴ� �̺�Ʈ
    public void OnBeginDrag(PointerEventData eventData)
    {
        //���Կ� �������� ���� ���
        if(item != null)
        {
            //�̱��濡 �ش� ���� ������ �Ҵ���
            DragSlot._instance._dragSlot = this;
            DragSlot._instance.DragSetImage(itemImage); //������ �̹��� �Ҵ�
            DragSlot._instance.transform.position = eventData.position; //�巡���� ��ü�� ��ġ�� �Ҵ�
        }
    }

    //���콺 �巡�� ���϶� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        //���Կ� �������� �ִ°��
        if(item != null)
        {
            DragSlot._instance.transform.position = eventData.position; //�̵��� ��ġ�� �Ҵ�
        }
    }

    //���콺 �巡�װ� �������� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        //������ ����� ����ǰ���
        if(DragSlot._instance.transform.localPosition.x < baseRect.xMin
            || DragSlot._instance.transform.localPosition.x > baseRect.xMax
            || DragSlot._instance.transform.localPosition.y < baseRect.yMin
            || DragSlot._instance.transform.localPosition.y > baseRect.yMax)
        {
            if(DragSlot._instance._dragSlot != null)
            {
                //���������� �������� ui �����
                theInputNumber.Call();
            }
        }
        else
        {
            //������ �����ϰ� ����
            DragSlot._instance.SetColor(0);
            DragSlot._instance._dragSlot = null; //���� ����
        }

    }

    //�ش� ���Կ� ���𰡰� ���콺 ��� ������ �߻��ϴ� �̺�Ʈ
    public void OnDrop(PointerEventData eventData)
    {
        //�巡�� ���϶�
        if(DragSlot._instance._dragSlot !=  null)
        {
            ChangeSlot();
        }
    }

    private void ChangeSlot()
    {
        
        Item _tempItem = item; //���Կ� �ִ� ������ �Ҵ�
        int _tempItemCount = itemCount; //���Կ� �ִ� ������ ���� �Ҵ�

        //�ش� ���Կ� �巡���� �������� ����
        AddItem(DragSlot._instance._dragSlot.item, DragSlot._instance._dragSlot.itemCount);

        //���� ���� �������� ������
        if(_tempItem != null)
        {
            //�巡���� ���Կ� ������ �Ҵ�(����)
            DragSlot._instance._dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            //���� ����
            DragSlot._instance._dragSlot.ClearSlot();
        }
    }

    //���콺�� ���� �����ȿ� �������� ����Ǵ� �̺�Ʈ
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            theItemEffectDatabase.ShowToolTip(item, transform.position);
        }
    }

    //���콺 Ŀ���� ���Կ��� ���ö� �ߵ�
    public void OnPointerExit(PointerEventData eventData)
    {
        theItemEffectDatabase.HideToolTip();
    }
}
