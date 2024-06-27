using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private EnemyMover _thisEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player)) 
        {
            _thisEnemy.SetPlayerToFollow(player);                                                       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _thisEnemy.StopFollowing();        
    }
}
