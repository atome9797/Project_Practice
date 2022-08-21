using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static bool isChangeWeapon = false;  // 무기 교체 중복 실행 방지. (True면 못하게)

    [SerializeField]
    private float changeweaponDelayTime;  // 무기 교체 딜레이 시간. 총을 꺼내기 위해 손 집어 넣는 그 시간. 대략 Weapon_Out 애니메이션 시간.
    [SerializeField]
    private float changeweaponEndDelayTime;  // 무기 교체가 완전히 끝난 시점. 대략 Weapon_In 애니메이션 시간.

    [SerializeField]
    private CloseWeapon[] hands;  //  Hand 형 무기를 가지는 배열

    // 관리 차원에서 이름으로 쉽게 무기 접근이 가능하도록 Dictionary 자료 구조 사용.
    private Dictionary<string, CloseWeapon> handDictionary = new Dictionary<string, CloseWeapon>();

    [SerializeField]
    private string currentWeaponType;  // 현재 무기의 타입 (총, 도끼 등등)
    
    public static Transform currentWeapon;  // 현재 무기. static으로 선언하여 여러 스크립트에서 클래스 이름으로 바로 접근할 수 있게 함.

    [SerializeField]
    private HandController theHandController; // 손 일땐 📜HandController.cs 활성화, 다른 무기일 땐 📜HandController.cs 비활성화


    void Start()
    {
       

        for (int i = 0; i < hands.Length; i++)
        {
            handDictionary.Add(hands[i].closeWeaponName, hands[i]);
        }
       
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        
        yield return new WaitForSeconds(changeweaponDelayTime);

        CancelPreWeaponAction();
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeweaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    private void CancelPreWeaponAction()
    {
        switch (currentWeaponType)
        {
         
            case "HAND":
                HandController.isActivate = false;
                break;
            
        }
    }

    private void WeaponChange(string _type, string _name)
    {
     
        if (_type == "HAND")
        {
            theHandController.CloseWeaponChange(handDictionary[_name]);
        }
    }
}