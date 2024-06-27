using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _takeDamageDuration;
    [SerializeField] private float _attackDuration;
        
    private string _isRunning = "IsRunning";
    private string _isJumping = "IsJumping";
    private string _isTakingDamage = "IsTakingDamage";
    private string _isAttacking = "IsAttacking";
    private bool _isJumpAnimationActive;

    public void RunRunAnimation()
    {
        if (_isJumpAnimationActive == false) 
        {
            _animator.SetBool(_isRunning, true);
        }        
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(_isRunning, false);
    }

    public void RunJumpAnimation() 
    {
        _isJumpAnimationActive = true;
        StopRunAnimation();
        _animator.SetBool(_isJumping, true);
    }
    
    public void StopJumpAnimation() 
    {
        _isJumpAnimationActive = false;
        _animator.SetBool(_isJumping, false);
    }

    public void RunTakeDamageAnimation() 
    {
        StartCoroutine(PlayAnimation(_isTakingDamage, _takeDamageDuration));    
    }

    public void RunAttackAnimation() 
    {
        StartCoroutine(PlayAnimation(_isAttacking, _attackDuration));
    }

    private IEnumerator PlayAnimation(string parameterName, float duration) 
    {
        WaitForSeconds wait = new WaitForSeconds(duration);

        _animator.SetBool(parameterName, true);

        yield return wait;

        _animator.SetBool(parameterName, false);
    }
}
