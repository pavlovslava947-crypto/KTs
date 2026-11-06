using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _productNameText;
    [SerializeField] private TMP_Text _productCostText;
    [SerializeField] private Button _buyButton;
    private string _name;
    private int _cost;
    private Basket _basket;

    public void Init(string name, int cost, Basket basket)
    {
        _name = name;
        _cost = cost;
        _basket = basket;

        _productNameText.text = name;
        _productCostText.text = cost + "$";

        _buyButton.onClick.RemoveAllListeners();
        _buyButton.onClick.AddListener(OnBuyClicked);

    }

    private void OnBuyClicked()
    {
        _basket.TargetProduct(_name, _cost);
    }
}
