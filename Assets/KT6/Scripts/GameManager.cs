using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Func<float> OnTakeInfo;
    public event Action<float> OnTakeDamage;

    [SerializeField] private float _time = 5f;
    [SerializeField] private int _enemyAmount = 2;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _canvas;
    private float _randomDamage;

    void Start()
    {
        EnemySpawn();
        StartCoroutine(InfoOutput());
    }

    private IEnumerator InfoOutput()
    {
        while (true)
        {
            _randomDamage = UnityEngine.Random.Range(0, 25);
            OnTakeInfo?.Invoke();
            OnTakeDamage?.Invoke(_randomDamage);

            yield return new WaitForSeconds(_time);
        }
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab, _canvas);
            RectTransform rect = enemy.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(100 * i, 200);
            enemy.Init(this);
        }
    }
}
