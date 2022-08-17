using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static bool isChangeWeapon = false; //무기 교체 중복 실행 방지

    [SerializeField]
    private float changeweaponDelayTime; //무기 교체 딜레이 시간

    [SerializeField]
    private float changeweaponEndDelayTime;//무기 교체가 완전히 끝난 시점

    [SerializeField]
    private Hand[] hands; //모든 종류의 Hand형 무기를 가지는 배열

    //관리 차원에서 이름으로 쉽게 무기 접근이 가능하도록 Dictionary 자료 구조 사용
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

}
