using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction _moveInput;
    [SerializeField] private InputAction _jumpAction;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _speed = 5;
    private bool _isGrounded = false;
    private Rigidbody2D rb;
    private PlayerShooting _playerShooting;

    private void Awake()
    {
        _playerShooting = GetComponent<PlayerShooting>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _moveInput.Enable();
        _jumpAction.Enable();
    }

    private void OnDestroy()
    {
        _moveInput.Disable();
        _jumpAction.Disable();
    }

    void Update()
    {
        float moveInput = _moveInput.ReadValue<float>();

       rb.linearVelocity = new Vector2(moveInput * _speed, rb.linearVelocity.y); 

        if (_jumpAction.WasPressedThisFrame() && _isGrounded)
        {
            rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }

        _playerShooting.Init(moveInput);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }


}
