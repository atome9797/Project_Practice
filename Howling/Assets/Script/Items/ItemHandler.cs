using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Transform Holder;//장비 배치 기준점
    public Transform rightHandMount1; //장비 오른쪽 손잡이, 오른손이 위치할 지점
    public Transform rightHandMount2; //장비 오른쪽 손잡이, 오른손이 위치할 지점
    public Transform rightHandMount3; //장비 오른쪽 손잡이, 오른손이 위치할 지점

    private Animator _animator; // 애니메이터 컴포넌트
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

    //역 운동학 설정
    void OnAnimatorIK()
    {
        if (radio != null)
        {
            if (radio.activeSelf == true)
            {
                //오른손
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
                //오른손
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
                //오른손
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount3.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount3.rotation);

            }
        }
      
    }

}
