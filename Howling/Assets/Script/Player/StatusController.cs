using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    //체력
    [SerializeField]
    private int hp = 100; //최대 체력
    [SerializeField]
    private int currnentHp = 100; //현제 체력


    //필요한 이미지
    [SerializeField]
    private Image[] images_Gauge;

    //각 상태를 나타내는 인덱스
    private const int HP = 0;

    private void Start()
    {
        currnentHp = hp;
    }

    private void Update()
    {
        GaugeUpdate();
    }

    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currnentHp / hp;
    }

    //체력 증가
    public void IncreaseHP(int _count)
    {
        //현재 hp + 증가량이 최대 체력 보다 작으면
        if(currnentHp + _count < hp)
        {
            currnentHp += _count;
        }
        else
        {
            currnentHp = hp; //아니면 풀피로 증가시킴
        }
    }

    //체력 감소
    public void DecreaseHP(int _count)
    {
        currnentHp -= _count;

        if(currnentHp <= 0)
        {
            Debug.Log("캐릭터의 체력이 0이 되었습니다.");
        }
    }



}
