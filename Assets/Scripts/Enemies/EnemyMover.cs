using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private PlayerTracker _tracker;
    [SerializeField] private float _speed;    

    private Vector3[] _waypoints;
    private int _currentWaypoint = 0;
    private bool _isPlayerInSight = false;
    private PlayerMover _playerInSight;

    private void Update()
    {
        if (_isPlayerInSight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerInSight.transform.position, _speed * Time.deltaTime);
        }
        else 
        {
            if (transform.position == _waypoints[_currentWaypoint])
            {
                _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);
        }        
    }

    public void SetWaypoints(Vector3[] waypoints) 
    {
        _waypoints = waypoints;                    
    }

    public void SetPlayerToFollow(PlayerMover player)
    {
        _playerInSight = player;
        _isPlayerInSight = true;
    }

    public void StopFollowing()
    {
        _isPlayerInSight = false;
    }
}
