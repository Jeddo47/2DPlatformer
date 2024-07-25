using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool _isAbleToJump = true;
    private float _lookRightAngle = 0;
    private float _lookLeftAngle = 180;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerAnimator.StopJumpAnimation();

        _isAbleToJump = true;
    }
    public void Jump()
    {
        if (_isAbleToJump)
        {
            _isAbleToJump = false;

            _playerAnimator.RunJumpAnimation();

            _playerRigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

    public void Move(float direction)
    {        
        if (direction > 0)
        {
            MoveInDirection(direction, _lookRightAngle);
        }
        else if (direction < 0)
        {
            MoveInDirection(-direction, _lookLeftAngle);
        }
        else
        {
            _playerAnimator.StopRunAnimation();
        }
    }

    private void MoveInDirection(float direction, float lookAngle)
    {
        transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.up);
        transform.Translate(Vector3.right * direction * _moveSpeed * Time.deltaTime);
        _playerAnimator.RunRunAnimation();
    }
}
