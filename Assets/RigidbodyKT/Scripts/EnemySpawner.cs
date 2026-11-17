using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Health _initialEnemyHealth; 
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _enemySpawnPos;

    private Health _currentEnemyHealth;

    private void Start()
    {
        if (_initialEnemyHealth != null)
        {
            SubscribeToEnemy(_initialEnemyHealth);
        }
        else
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private void SubscribeToEnemy(Health enemyHealth)
    {
        _currentEnemyHealth = enemyHealth;
        _currentEnemyHealth.OnEnemyDie += OnEnemyDie;
    }

    private void OnEnemyDie()
    {
       
        if (_currentEnemyHealth != null)
        {
            _currentEnemyHealth.OnEnemyDie -= OnEnemyDie;
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);

        GameObject enemy = Instantiate(_enemyPrefab, _enemySpawnPos);

        
        if (enemy.TryGetComponent<Health>(out var newHealth))
        {
            SubscribeToEnemy(newHealth);
        }
    }

    private void OnDestroy()
    {
        if (_currentEnemyHealth != null)
        {
            _currentEnemyHealth.OnEnemyDie -= OnEnemyDie;
        }
    }
}
