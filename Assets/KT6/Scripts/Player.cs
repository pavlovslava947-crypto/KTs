using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ButtonHeal _buttonHeal;
    [SerializeField] private ButtonDmg _buttonDmg;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private TextMeshProUGUI _healthText;


    private void Start()
    {
        _buttonHeal.OnHealChanged += Damage;
        _buttonDmg.OnDamageChanges += Threatment;
        _gameManager.OnTakeInfo += TakeInfo;
    }

    private void Damage(float amount)
    {
        _currentHealth -= amount;

        _healthText.text = _currentHealth.ToString("F0") + " / 100";

        if (_currentHealth < 0) Die();
    }

    private void Threatment(float amount)
    {
        _currentHealth += amount;

        _healthText.text = _currentHealth.ToString("F0") + " / 100";
    }

    private void Die()
    {
        Debug.Log("Игрок умер");

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _buttonHeal.OnHealChanged -= Damage;
        _buttonDmg.OnDamageChanges -= Threatment;
        _gameManager.OnTakeInfo -= TakeInfo;
    }

    float TakeInfo()
    {
        Debug.Log(_currentHealth);

        return _currentHealth;
    }


}
