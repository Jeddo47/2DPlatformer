using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class ItemsCollector : MonoBehaviour
{
    [SerializeField] private CharacterStats _playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit) && _playerStats.HitPoints < _playerStats.MaxHitPoints) 
        {
            _playerStats.ChangeHitPoints(fruit.HPRegenAmount);
            Destroy(collision.gameObject);
        }
    }
}
