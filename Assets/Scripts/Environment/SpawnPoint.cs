using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _patrolDistance;

    public Vector3[] Waypoints { get; private set; }

    private void Awake()
    {
        Waypoints = new Vector3[2] { new Vector3(transform.position.x - _patrolDistance, transform.position.y, transform.position.z), 
                                 new Vector3(transform.position.x + _patrolDistance, transform.position.y, transform.position.z) };
    }        
}
