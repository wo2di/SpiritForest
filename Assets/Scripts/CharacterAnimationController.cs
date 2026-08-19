using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    
    private Animator animator;
    //private Vector2 idleDir;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIdleDirection(Vector2 dir)
    {
        //idleDir = dir;
        animator.SetFloat(AnimatorHash.LastMoveXHash, dir.x);
        animator.SetFloat(AnimatorHash.LastMoveYHash, dir.y);
    }

    public void SetMoveDirection(Vector2 dir)
    {

        animator.SetFloat(AnimatorHash.MoveXHash, dir.x);
        animator.SetFloat(AnimatorHash.MoveYHash, dir.y);
        if (dir != Vector2.zero)
        {
            animator.SetBool(AnimatorHash.IsMovingHash, true);
        }
        else
        {
            animator.SetBool(AnimatorHash.IsMovingHash, false);
        }
    }
}
