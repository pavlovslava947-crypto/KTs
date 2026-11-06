using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProductController : MonoBehaviour
{
    [SerializeField] private List<int> _costs = new List<int>();
    [SerializeField] private List<string> _names = new List<string>();
    [SerializeField] private ProductCard _productCardPrefab;
    [SerializeField] private Transform _panel;
    [SerializeField] private Basket _basket;
    [SerializeField] private BusketItem _busketItem;
    [SerializeField] private TextMeshProUGUI _sumText;
    private List<ProductCard> _spawnedCards = new List<ProductCard>();

    void Start()
    {
        Output();
        SumCalc();
    }

    void Output()
    {
        for (int i = 0; i < _names.Count; i++)
        {
            Debug.Log($"{_names[i]}, цена: {_costs[i]}$ ");
            ProductCard productCard = Instantiate(_productCardPrefab, _panel);
            _spawnedCards.Add(productCard);

            productCard.Init(_names[i], _costs[i], _basket);
        }
    }

    public void OnNextDay()
    {

        for (int i = 0; i < _costs.Count; i++)
        {
            _costs[i] *= 2;

        }

       
        for (int i = 0; i < _spawnedCards.Count; i++)
        {
            _spawnedCards[i].Init(_names[i], _costs[i], _basket);
            _busketItem.Setup(_names[i], _costs[i]);
        }

        SumCalc();
    }

    public string SumCalc()
    {
        _sumText.text = "Сумма: " + _costs.Sum();

        return _sumText.text;
    }
}
