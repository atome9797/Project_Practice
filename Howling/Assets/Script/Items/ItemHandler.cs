using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform Holder;//장비 배치 기준점
    public Transform rightHandMount; //장비 오른쪽 손잡이, 오른손이 위치할 지점

    private Animator _animator; // 애니메이터 컴포넌트
    private GameObject radio = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        radio = GameObject.FindWithTag("Radio");
    }

    //역 운동학 설정
    void OnAnimatorIK()
    {
        if(radio != null)
        {
            if (radio.activeSelf == true)
            {
                //오른손
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);

            }

        }
    }

}
