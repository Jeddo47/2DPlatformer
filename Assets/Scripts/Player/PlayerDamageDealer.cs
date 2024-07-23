using System.Collections;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private float _attackTime;

    public bool IsAttacking { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
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
