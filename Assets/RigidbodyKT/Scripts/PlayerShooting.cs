using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputAction _shootAction;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force = 5f;
   
    void Start()
    {
        _shootAction.Enable();
    }

    
    void Update()
    {
        if (_shootAction.WasPressedThisFrame())
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.right * _force, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, 1.5f);
        }
    }
}
