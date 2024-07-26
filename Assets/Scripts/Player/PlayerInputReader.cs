using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJumping;
    private bool _isAttacking;
    private bool _isCasting;

    public float Direction { get; private set; }

    private void Update()
    {
        ReadMove();
        ReadJump();
        ReadAttack();
        ReadCastLifeLeech();
    }

    public bool GetIsJumping()
    {
        return GetBoolValue(ref _isJumping);
    }

    public bool GetIsAttacking() 
    {
        return GetBoolValue(ref _isAttacking);
    }

    public bool GetIsCasting() 
    {
        return GetBoolValue(ref _isCasting);
    }

    private bool GetBoolValue(ref bool boolValue)
    {
        bool currentValue = boolValue;

        boolValue = false;

        return currentValue;
    }

    private void ReadMove()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void ReadJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    private void ReadAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isAttacking = true;
        }
    }

    private void ReadCastLifeLeech()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _isCasting = true;
        }
    }
}
