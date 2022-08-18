using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static bool isChangeWeapon = false; //���� ��ü �ߺ� ���� ����

    [SerializeField]
    private float changeweaponDelayTime = 1f; //���� ��ü ������ �ð�

    [SerializeField]
    private float changeweaponEndDelayTime = 1f;//���� ��ü�� ������ ���� ����

    [SerializeField]
    private Hand[] hands; //��� ������ Hand�� ���⸦ ������ �迭

    //���� �������� �̸����� ���� ���� ������ �����ϵ��� Dictionary �ڷ� ���� ���
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    [SerializeField]
    private string currentWeaponType; //��ä ������ Ÿ�� (��, �������)
    public static Transform currentWeapon; //������ ����.
    
    [SerializeField]
    private HandController theHandController;//���϶� HandController Ȱ��ȭ

    private void Start()
    {
        for(int i = 0; i < hands.Length; i++)
        {
            //�ڵ� �̸��� ��ü�� �޾ƿ�
            handDictionary.Add(hands[i].handName, hands[i]);
        }
    }


    private void Update()
    {
        if(!isChangeWeapon)
        {
            //1�� ������ �Ǽչ���� ��ü
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ChangeWeaponCoroutine("HAND", "�Ǽ�"));
            }
        }
    }

    //���� ��ü�� Equipment, Radio���� ����
    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        
        yield return new WaitForSeconds(changeweaponDelayTime);

        CancelPreWeaponAction();

        //handDictionary[�Ǽ�] �� 
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeweaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    //��� �ִ� ���� ������
    private void CancelPreWeaponAction()
    {
        switch(currentWeaponType)
        {
            case "HAND":
                HandController.isActivate = false;
                break;
        }
    }

    //����� �ϴ� ������� ���
    private void WeaponChange(string _type, string  _name)
    {
        if (_type == "HAND")
        {
            //�ڵ� ��ü�� ���������� ü������
            theHandController.HandChange(handDictionary[_name]);
        }
    }
}
