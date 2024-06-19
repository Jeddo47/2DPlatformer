using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool _isAbleToJump = true;
    private float _lookRightAngle = 0;
    private float _lookLeftAngle = 180;

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerAnimator.StopJumpAnimation();

        _isAbleToJump = true;
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction > 0)
        {
            transform.rotation = Quaternion.AngleAxis(_lookRightAngle, Vector3.up);
            transform.Translate(Vector3.right * direction * _moveSpeed * Time.deltaTime);
            _playerAnimator.RunRunAnimation();
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.AngleAxis(_lookLeftAngle, Vector3.up);
            transform.Translate(Vector3.right * -direction * _moveSpeed * Time.deltaTime);
            _playerAnimator.RunRunAnimation();
        }
        else 
        {
            _playerAnimator.StopRunAnimation();        
        }
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isAbleToJump) 
        {
            _isAbleToJump = false;

            _playerAnimator.RunJumpAnimation();

            this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _jumpForce);        
        }                    
    }
}
