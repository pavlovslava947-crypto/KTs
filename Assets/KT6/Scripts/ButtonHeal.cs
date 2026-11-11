using System;
using UnityEngine;

public class ButtonHeal : MonoBehaviour
{
    public event Action<float> OnHealChanged;

    [SerializeField] private float _treatmentAmount;

    public void OnButtonClick()
    {
        OnHealChanged?.Invoke(_treatmentAmount);
    }
}
