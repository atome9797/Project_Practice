using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public string handName;  // ��Ŭ�̳� �� �� ����. �̸����� ������ ���̴�.
    public float range; // ���� ����. ���� ������ ������ ������ ������
    public int damage; // ���ݷ�
    public float workSpeed; // �۾� �ӵ�
    public float attackDelay;  // ���� ������. ���콺 Ŭ���ϴ� ���� ���� ������ �� �����Ƿ�.
    public float attackDelayA;  // ���� Ȱ��ȭ ����. ���� �ִϸ��̼� �߿��� �ָ��� �� �������� �� ���� ���� �������� ���� �Ѵ�.
    public float attackDelayB;  // ���� ��Ȱ��ȭ ����. ���� �� ������ �ָ��� ���� �ִϸ��̼��� ���۵Ǹ� ���� �������� ���� �ȵȴ�.

    public Animator anim;  // �ִϸ����� ������Ʈ
    // public BoxCollider boxCollider; 
}