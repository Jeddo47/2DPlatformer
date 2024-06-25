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
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

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

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isAbleToJump) 
        {
            _isAbleToJump = false;

            _playerAnimator.RunJumpAnimation();

            _playerRigidbody.AddForce(Vector3.up * _jumpForce);        
        }                    
    }
}
