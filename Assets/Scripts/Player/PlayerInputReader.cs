using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;
    [SerializeField] private LifeLeechCaster _lifeLeechCaster;

    void Update()
    {
        Move();
        Jump();
        Attack();
        CastLifeLeech();
    }

    private void Move()
    {
        _playerMover.Move(Input.GetAxis(Horizontal));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.Jump();
        }
    }

    private void Attack() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            _playerDamageDealer.Attack();
        }            
    }

    private void CastLifeLeech() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            _lifeLeechCaster.CastLifeLeech();        
        }   
    }
}
