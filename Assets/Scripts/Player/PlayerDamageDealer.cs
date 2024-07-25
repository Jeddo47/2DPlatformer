using System.Collections;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private float _attackTime;

    public bool IsAttacking { get; private set; }

    public void Attack()
    {
        if (IsAttacking == false)
        {
            StartCoroutine(AttackEnemy());
        }
    }

    private IEnumerator AttackEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackTime);
        _playerAnimator.RunAttackAnimation();
        IsAttacking = true;

        yield return wait;

        IsAttacking = false;
    }
}
