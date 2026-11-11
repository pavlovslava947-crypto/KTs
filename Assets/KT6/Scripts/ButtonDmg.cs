using System;
using UnityEngine;

public class ButtonDmg : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    public event Action<float> OnDamageChanges;
    
    public void OnButtonClick()
    {
        OnDamageChanges?.Invoke(_damageAmount);
    }
}
