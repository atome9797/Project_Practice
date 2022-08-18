using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform Holder;//��� ��ġ ������
    public Transform rightHandMount; //��� ������ ������, �������� ��ġ�� ����

    private Animator _animator; // �ִϸ����� ������Ʈ

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //�� ��� ����
    private void OnAnimatorIK(int layerIndex)
    {

        float x = 0f;
        float y = 2f;
        float z = 0.7f;
        Holder.position = new Vector3(x, y, z);

        //������
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

        _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);

    }

}
