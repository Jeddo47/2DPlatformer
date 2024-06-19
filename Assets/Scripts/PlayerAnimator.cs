using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _isRunning = "IsRunning";
    private string _isJumping = "IsJumping";

    public void RunRunAnimation()
    {
        _animator.SetBool(_isRunning, true);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(_isRunning, false);
    }

    public void RunJumpAnimation() 
    {
        _animator.SetBool(_isJumping, true);
    }
    
    public void StopJumpAnimation() 
    {
        _animator.SetBool(_isJumping, false);
    }
}
