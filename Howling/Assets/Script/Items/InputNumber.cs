using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNumber : MonoBehaviour
{
    //입력 필드가 활성화 되어 있을땐 true, 비활성화 상태일때 false
    private bool activated = false;

    //placeholder 의 텍스트 드롭된 아이템의 개수가 표시됨
    [SerializeField]
    private Text text_Preview;

    // 사용자가 실제로 입력한 문자열이 들어갈 텍스트.
    [SerializeField]
    private Text text_Input;

    //Input Field 의 텍스트를 참조하기 위해 Input Field 타입으로 선언.
    [SerializeField]
    private InputField if_text;

    //Input Field 입력 필드 UI 오브젝트가 할당 될 것
    [SerializeField]
    private GameObject go_Base;

    //카메라의 앞에서 버린 아이템을 생성하기 위해 ActionController.cs 참조
    [SerializeField]
    private ActionController thePlayer;

    

    private void Update()
    {
        if(activated)
        {
            //엔터키 눌렀을때 발생하는 이벤트
            if(Input.GetKeyDown(KeyCode.Return))
            {
                OK();
            }
            else if(Input.GetKeyDown(KeyCode.Escape)) //ESC 키 눌렀을때 발생하는 이벤트
            {
                Cancel();
            }
        }
    }


    //입력 필드 불러오기
    public void Call()
    {
        //InputNumber 활성화
        go_Base.SetActive(true);
        activated = true;
        //InputNumber 초기화
        if_text.text = "";
        //Placeholder의 텍스트를 드래그 된 슬롯의 아이템 갯수로 한다.
        text_Preview.text = DragSlot._instance._dragSlot.itemCount.ToString();
    }


    public void Cancel()
    {
        activated = false;
        DragSlot._instance.SetColor(0);
        go_Base.SetActive(false);
        DragSlot._instance._dragSlot = null;
    }    



    public void OK()
    {
        DragSlot._instance.SetColor(0);

        int num;

        if(text_Input.text != "")
        {
            //숫자만 있다면실행
            if(CheckNumber(text_Input.text))
            {
                num = int.Parse(text_Input.text);

                //입력값이 슬롯 숫자보다 많으면 슬롯 최대 숫자만큼으로 지정함
                if(num > DragSlot._instance._dragSlot.itemCount)
                {
                    num = DragSlot._instance._dragSlot.itemCount;
                }
            }
            else //숫자만 있는게 아니면 1 실행
            {
                num = 1;
            }
        }
        else
        {
            num = int.Parse(text_Preview.text);
        }

        //입력 한 개수 만큼 프리팹을 실제로 생성한다.
        StartCoroutine(DropItemCoroutine(num));
    }

    IEnumerator DropItemCoroutine(int num)
    {
        for(int i = 0; i < num; i++)
        {
            //카메라 시점으로의 위치에 생성되게 설정
            Instantiate(DragSlot._instance._dragSlot.item.itemPrefab, thePlayer.transform.position + thePlayer.transform.forward, Quaternion.identity);
            
            //슬롯 아이템 -1 해주기
            DragSlot._instance._dragSlot.SetSlotCount(-1);
            yield return new WaitForSeconds(0.05f);
        }

        DragSlot._instance._dragSlot = null;
        go_Base.SetActive(false);
        activated = false;
    }

    private bool CheckNumber(string _argString)
    {
        char[] _tempCharArray = _argString.ToCharArray();
        bool isNumber = true;

        for(int i = 0; i < _tempCharArray.Length; i++)
        {
            //아스키 코드로 숫자인지 판단
            if(_tempCharArray[i] >= 48 && _tempCharArray[i] <= 57)
            {
                continue;
            }
            isNumber = false;
        }

        return isNumber;
    }

}
