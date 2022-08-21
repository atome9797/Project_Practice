using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    //마우스 드래그 끝났을때 발생하는 이벤트
    private Rect baseRect; //Inventory_Base 이미지의 Rect 정보를 받아옴

    private ItemEffectDatabase theItemEffectDatabase;

    public Item item; //획득한 아이템
    public int itemCount; //획득한 아이템의 개수
    public Image itemImage; //아이템의 이미지

    [SerializeField]
    private Text text_Count; //아이템 갯수
    [SerializeField]
    private GameObject go_CountImage; //아이템 이미지

    private InputNumber theInputNumber;

    private void Start()
    {
        //FindObjectOfType 사용한 이유 : 게임 도중 생성될 예정인 프리팹은 SerializeField인것들은 자신의 객체만 참조 가능하기 때문에 None이 되어버림
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();

        //Inventory_Base 의 transform 정보 받아옴
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;

        theInputNumber = FindObjectOfType<InputNumber>();
    }

    //아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage; //아이템 이미지를 sprite 에 저장

        //무기가 아니면
        if(item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true); //아이템 이미지 보이게 설정
            text_Count.text = itemCount.ToString(); //아이템 1로 설정
        }
        else //무기는 아이템 개수 안보이게 설정
        {
            text_Count.text = "0"; //아이템 0으로 설정
            go_CountImage.SetActive(false); //아이템 이미지 안보이게 설정
        }

        //반투명 상태로 설정했던 이미지 보이게 설정
        SetColor(1); 
    }

    //해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if(itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //해당 슬롯 비우기
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    //마우스 클릭될때 발생하는 이벤트 함수
    public void OnPointerClick(PointerEventData eventData)
    {
        //우클릭 했을 경우
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            //슬롯에 아이템이 있을경우
            if(item != null)
            {
                theItemEffectDatabase.UseItem(item);
                
                SetSlotCount(-1);
                
            }
        }
    }


    //마우스 드래그가 실행됬을때 발생하는 이벤트
    public void OnBeginDrag(PointerEventData eventData)
    {
        //슬롯에 아이템이 있을 경우
        if(item != null)
        {
            //싱글톤에 해당 슬롯 정보를 할당함
            DragSlot._instance._dragSlot = this;
            DragSlot._instance.DragSetImage(itemImage); //아이템 이미지 할당
            DragSlot._instance.transform.position = eventData.position; //드래그한 객체의 위치를 할당
        }
    }

    //마우스 드래그 중일때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        //슬롯에 아이템이 있는경우
        if(item != null)
        {
            DragSlot._instance.transform.position = eventData.position; //이동중 위치를 할당
        }
    }

    //마우스 드래그가 끝났을때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        //범위를 벗어나면 실행되게함
        if(DragSlot._instance.transform.localPosition.x < baseRect.xMin
            || DragSlot._instance.transform.localPosition.x > baseRect.xMax
            || DragSlot._instance.transform.localPosition.y < baseRect.yMin
            || DragSlot._instance.transform.localPosition.y > baseRect.yMax)
        {
            if(DragSlot._instance._dragSlot != null)
            {
                //프리팹으로 생성해줄 ui 띄워줌
                theInputNumber.Call();
            }
        }
        else
        {
            //슬롯을 투명하게 변경
            DragSlot._instance.SetColor(0);
            DragSlot._instance._dragSlot = null; //슬롯 비우기
        }

    }

    //해당 슬롯에 무언가가 마우스 드롭 됬을때 발생하는 이벤트
    public void OnDrop(PointerEventData eventData)
    {
        //드래그 중일때
        if(DragSlot._instance._dragSlot !=  null)
        {
            ChangeSlot();
        }
    }

    private void ChangeSlot()
    {
        
        Item _tempItem = item; //슬롯에 있는 아이템 할당
        int _tempItemCount = itemCount; //슬롯에 있는 아이템 개수 할당

        //해당 슬롯에 드래그한 아이템을 담음
        AddItem(DragSlot._instance._dragSlot.item, DragSlot._instance._dragSlot.itemCount);

        //이전 슬롯 아이템이 있으면
        if(_tempItem != null)
        {
            //드래그한 슬롯에 아이템 할당(스왑)
            DragSlot._instance._dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            //슬롯 비우기
            DragSlot._instance._dragSlot.ClearSlot();
        }
    }

    //마우스가 슬롯 범위안에 들어왔을때 실행되는 이벤트
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            theItemEffectDatabase.ShowToolTip(item, transform.position);
        }
    }

    //마우스 커서가 슬롯에서 나올때 발동
    public void OnPointerExit(PointerEventData eventData)
    {
        theItemEffectDatabase.HideToolTip();
    }
}
