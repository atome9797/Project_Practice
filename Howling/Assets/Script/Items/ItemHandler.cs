using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform Holder;//��� ��ġ ������
    public Transform rightHandMount; //��� ������ ������, �������� ��ġ�� ����

    private Animator _animator; // �ִϸ����� ������Ʈ
    private GameObject radio = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        radio = GameObject.FindWithTag("Radio");
    }

    //�� ��� ����
    void OnAnimatorIK()
    {
        if(radio != null)
        {
            if (radio.activeSelf == true)
            {
                //������
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);

            }

        }
    }

}
