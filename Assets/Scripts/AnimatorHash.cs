using UnityEngine;

public static class AnimatorHash
{
    public static readonly int LastMoveXHash = Animator.StringToHash("LastMoveX");
    public static readonly int LastMoveYHash = Animator.StringToHash("LastMoveY");
    public static readonly int MoveXHash = Animator.StringToHash("MoveX");
    public static readonly int MoveYHash = Animator.StringToHash("MoveY");
    public static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
}