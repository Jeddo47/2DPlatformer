using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;
    [SerializeField] private Vector3 _offsetOne;
    [SerializeField] private Vector3 _offsetTwo;
    [SerializeField] private float _positionY;
    [SerializeField] private float _positionYBreakpoint;

    void Update()
    {
        Vector3 chosenOffset = GetOffset();

        Vector3 newPosition = new Vector3(_player.transform.position.x + chosenOffset.x, _positionY + chosenOffset.y, transform.position.z);

        transform.position = newPosition;                
    }

    private Vector3 GetOffset() 
    {
        if (_player.transform.position.y <= _positionYBreakpoint)
        {
            return _offsetOne;
        }
        else 
        {
            return _offsetTwo;        
        }
    }
}
