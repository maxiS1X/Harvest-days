using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speedRun;

    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    public bool canMove;

    private void Start()
    {
        canMove = true;
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
        Run(Input.GetKey(KeyCode.LeftShift));
        Sit(Input.GetKey(KeyCode.LeftControl));
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        _walkDirection = transform.right * x + transform.forward * z;
        _walkDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Walk(_walkDirection);
        DoGravity(_characterController.isGrounded);
    }

    private void Walk(Vector3 direction)
    {
        if (canMove == true)
        {
            _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
        }
    }

    private void DoGravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -1f;
            
        }
        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
            _velocity.y = _jumpPower;
    }

    private void Run(bool canRun)
    {
        _speedWalk = canRun ? _speedRun : _speed;
    }

    private void Sit(bool canSit)
    {
        _characterController.height = canSit ? 0.5f : 1f;
    }
}