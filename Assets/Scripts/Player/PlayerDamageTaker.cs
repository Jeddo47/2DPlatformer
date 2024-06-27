using UnityEngine;

public class PlayerDamageTaker : MonoBehaviour
{
    [SerializeField] private CharacterStats _playerStats;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;
    [SerializeField] private float _knockbackPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyDamageDealer>(out _) && collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats enemyStats) && 
            _playerDamageDealer.IsAttacking == false) 
        {
            _playerStats.ChangeHitPoints(-enemyStats.Damage);
            _playerAnimator.RunTakeDamageAnimation();
            this.GetComponent<Rigidbody2D>().AddForce((transform.position - enemyStats.transform.position).normalized * _knockbackPower, ForceMode2D.Impulse);
        }
    }
}
