using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3[] _waypoints;
    private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint]) 
        {
            _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;        
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);
    }

    public void SetWaypoints(Vector3[] waypoints) 
    {
        _waypoints = waypoints;                    
    }
}
