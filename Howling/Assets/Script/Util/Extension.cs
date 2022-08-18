using UnityEngine;

public static class Extension
{
    public static void SetIKTransformAndWeight(this Animator animator, AvatarIKGoal goal, Transform goalTransform, float weight = 1f)
    {
        animator.SetIKPosition(goal, goalTransform.position);
        animator.SetIKRotation(goal, goalTransform.rotation);
    }
}
