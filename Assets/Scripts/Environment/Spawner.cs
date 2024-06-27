using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private EnemyMover _enemyPrefab;

    private void Awake()
    {
        foreach (var spawnPoint in _spawnPoints) 
        {
            EnemyMover enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemy.SetWaypoints(spawnPoint.Waypoints);
        }
    }
}
