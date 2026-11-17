using System.Collections;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _bulletDestroySpeed = 2.5f;
    [SerializeField] private float _interval = 2f;
    private float _timer;

    private void Start()
    {
        _timer = _interval;
    }

    private void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        if(_timer <= 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.right * _force, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, _bulletDestroySpeed);

            _timer = _interval;
        }
    }




}
