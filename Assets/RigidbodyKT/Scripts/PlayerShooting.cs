using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputAction _shootAction;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _bulletDestroySpeed = 2.5f;
    private float _playerVelocity;
   
    void OnEnable()
    {
        _shootAction.Enable();
    }

    private void OnDestroy()
    {
        _shootAction.Disable();
    }


    void Update()
    {
        if (_shootAction.WasPressedThisFrame())
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if(_playerVelocity < 0.1) rb.AddForce(-_firePoint.right * _force, ForceMode2D.Impulse);
            if (_playerVelocity > 0.1) rb.AddForce(_firePoint.right * _force, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, _bulletDestroySpeed);
        }

       
    }

    public void Init(float velocity)
    {
        _playerVelocity = velocity;
    }
}
