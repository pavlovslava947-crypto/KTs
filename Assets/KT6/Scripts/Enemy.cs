using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private float _enemyHealth = 100f;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void Init(GameManager gm)
    {
        _gameManager = gm;
        _gameManager.OnTakeDamage += TakeDamage;
    }

    private void TakeDamage(float amount)
    {
        _enemyHealth -= amount;

        Debug.Log("Здоровье врага: " + _enemyHealth);
        Debug.Log("нанесен урон: " +  amount);
        _healthText.text = _enemyHealth.ToString("F1");

        if(_enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _gameManager.OnTakeDamage -= TakeDamage;

        Debug.Log("враг погиб");

        Destroy(gameObject);
    }

}
