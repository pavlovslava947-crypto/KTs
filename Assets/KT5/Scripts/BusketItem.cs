using TMPro;
using UnityEngine;

public class BusketItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _busketText;
    
    public void Setup(string name, int cost)
    {
        _busketText.text = $"{name} - {cost}";
    }
}
