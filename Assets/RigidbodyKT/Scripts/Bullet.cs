using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }
}
