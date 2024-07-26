using UnityEngine;

public class PlayerInputProcessor : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;
    [SerializeField] private LifeLeechCaster _lifeLeechCaster;

    private void FixedUpdate()
    {
        _playerMover.Move(_playerInputReader.Direction);

        if (_playerInputReader.GetIsJumping())
        {
            _playerMover.Jump();
        }

        if (_playerInputReader.GetIsAttacking())
        {
            _playerDamageDealer.Attack();
        }

        if (_playerInputReader.GetIsCasting())
        {
            _lifeLeechCaster.CastLifeLeech();
        }
    }
}
