using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewProduct", menuName = "Scriptable Objects/ProductData")]
public class ProductData : ScriptableObject
{
    [SerializeField] private string _productName = "Новый продукт";
    [SerializeField] private string _description = "Описание";
    [SerializeField] private int _productCost = 100;

    public string ProductName => _productName;
    public string Description => _description;
    public int ProductCost => _productCost;
   
}
