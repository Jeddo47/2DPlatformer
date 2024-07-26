using UnityEngine;

public class EnemyDamageTaker : MonoBehaviour
{
    [SerializeField] private CharacterStats _enemyStats;
    [SerializeField] private float _knockbackPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerDamageDealer>(out PlayerDamageDealer playerDamageDealer) && playerDamageDealer.IsAttacking == true &&
            collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats playerStats))
        {
            _enemyStats.RemoveHitPoints(playerStats.Damage);
            GetComponent<Rigidbody2D>().AddForce((transform.position - playerStats.transform.position).normalized * _knockbackPower, ForceMode2D.Impulse);
        }
    }
}
