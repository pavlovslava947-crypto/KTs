using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float _health = 100f;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private GameObject _player;
    public event Action OnEnemyDie;
    private string sceneName = "RigidbodyKT";

    public void TakeDamage(float amount)
    {
        _health -= amount;

        UpdateUI();

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(gameObject == _player)
        {
            SceneManager.LoadScene(sceneName);
        }

        OnEnemyDie?.Invoke();

        Destroy(gameObject);
    }

    void UpdateUI()
    {
        _healthText.text = _health.ToString();
    }
}
