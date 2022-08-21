using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    //ü��
    [SerializeField]
    private int hp = 100; //�ִ� ü��
    [SerializeField]
    private int currnentHp = 100; //���� ü��


    //�ʿ��� �̹���
    [SerializeField]
    private Image[] images_Gauge;

    //�� ���¸� ��Ÿ���� �ε���
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

    //ü�� ����
    public void IncreaseHP(int _count)
    {
        //���� hp + �������� �ִ� ü�� ���� ������
        if(currnentHp + _count < hp)
        {
            currnentHp += _count;
        }
        else
        {
            currnentHp = hp; //�ƴϸ� Ǯ�Ƿ� ������Ŵ
        }
    }

    //ü�� ����
    public void DecreaseHP(int _count)
    {
        currnentHp -= _count;

        if(currnentHp <= 0)
        {
            Debug.Log("ĳ������ ü���� 0�� �Ǿ����ϴ�.");
        }
    }



}
