using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static bool isChangeWeapon = false; //무기 교체 중복 실행 방지

    [SerializeField]
    private float changeweaponDelayTime = 1f; //무기 교체 딜레이 시간

    [SerializeField]
    private float changeweaponEndDelayTime = 1f;//무기 교체가 완전히 끝난 시점

    [SerializeField]
    private Hand[] hands; //모든 종류의 Hand형 무기를 가지는 배열

    //관리 차원에서 이름으로 쉽게 무기 접근이 가능하도록 Dictionary 자료 구조 사용
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    [SerializeField]
    private string currentWeaponType; //현채 무기의 타입 (총, 도끼등등)
    public static Transform currentWeapon; //현재의 무기.
    
    [SerializeField]
    private HandController theHandController;//손일땐 HandController 활성화

    private void Start()
    {
        for(int i = 0; i < hands.Length; i++)
        {
            //핸드 이름과 객체를 받아옴
            handDictionary.Add(hands[i].handName, hands[i]);
        }
    }


    private void Update()
    {
        if(!isChangeWeapon)
        {
            //1번 누르면 맨손무기로 교체
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ChangeWeaponCoroutine("HAND", "맨손"));
            }
        }
    }

    //라디오 객체면 Equipment, Radio으로 들어옴
    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        
        yield return new WaitForSeconds(changeweaponDelayTime);

        CancelPreWeaponAction();

        //handDictionary[맨손] 의 
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeweaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    //들고 있던 무기 내리기
    private void CancelPreWeaponAction()
    {
        switch(currentWeaponType)
        {
            case "HAND":
                HandController.isActivate = false;
                break;
        }
    }

    //들고자 하는 새무기로 들기
    private void WeaponChange(string _type, string  _name)
    {
        if (_type == "HAND")
        {
            //핸드 객체의 아이템으로 체인지함
            theHandController.HandChange(handDictionary[_name]);
        }
    }
}
