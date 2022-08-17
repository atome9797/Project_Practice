using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static bool isChangeWeapon = false; //���� ��ü �ߺ� ���� ����

    [SerializeField]
    private float changeweaponDelayTime; //���� ��ü ������ �ð�

    [SerializeField]
    private float changeweaponEndDelayTime;//���� ��ü�� ������ ���� ����

    [SerializeField]
    private Hand[] hands; //��� ������ Hand�� ���⸦ ������ �迭

    //���� �������� �̸����� ���� ���� ������ �����ϵ��� Dictionary �ڷ� ���� ���
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

}
