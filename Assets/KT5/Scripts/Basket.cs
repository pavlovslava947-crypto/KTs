using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private BusketItem _text;
    [SerializeField] private Transform _busketPanel;
   
    public void TargetProduct(string productName , int ProductCost)
    {
        BusketItem text = Instantiate(_text, _busketPanel);
        text.Setup(productName, ProductCost);
    }
}
