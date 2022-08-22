using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform Holder;//��� ��ġ ������
    public Transform rightHandMount1; //��� ������ ������, �������� ��ġ�� ����
    public Transform rightHandMount2; //��� ������ ������, �������� ��ġ�� ����
    public Transform rightHandMount3; //��� ������ ������, �������� ��ġ�� ����

    private Animator _animator; // �ִϸ����� ������Ʈ
    private GameObject radio = null;
    private GameObject GoldKey = null;
    private GameObject SilverKey = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        radio = GameObject.FindWithTag("Radio");
        GoldKey = GameObject.FindWithTag("GoldKey");
        SilverKey = GameObject.FindWithTag("SilverKey");
    }

    //�� ��� ����
    void OnAnimatorIK()
    {
        if (radio != null)
        {
            if (radio.activeSelf == true)
            {
                //������
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount1.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount1.rotation);

            }
        }

        else if (GoldKey != null)
        {
            if (GoldKey.activeSelf == true)
            {
                //������
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount2.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount2.rotation);

            }
        }

        else if (SilverKey != null)
        {
            if (SilverKey.activeSelf == true)
            {
                //������
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount3.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount3.rotation);

            }
        }
      
    }

}
