using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProductController : MonoBehaviour
{
    [SerializeField] private List<ProductData> _productScrObjs = new List<ProductData>();
    [SerializeField] private GameObject _productCard;
    [SerializeField] private Transform _canvas;
    [SerializeField] private float _interval = 3f;
    [SerializeField] private Vector2 _spawnPos = new Vector2 (0, 454);
    [SerializeField] private TextMeshProUGUI _productNameText;
    [SerializeField] private TextMeshProUGUI _productCostText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ProductOutput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ProductOutput()
    {
        int _sum = 0;
        foreach(ProductData data in _productScrObjs)
        {
            Debug.Log(data.ProductName);
            Debug.Log(data.Description);
            Debug.Log(data.ProductCost + "$");
            
            _sum += data.ProductCost;
            Debug.Log("сумма всех товаров: " + _sum);
            
            
            SpawnProductCard();
            _productNameText.text = data.ProductName;
            _productCostText.text = data.ProductCost + "$";
        }
    }

    GameObject SpawnProductCard()
    {
        GameObject productCard = Instantiate(_productCard, _canvas);
        
   
        _spawnPos.y -= _interval;

        productCard.transform.localPosition = _spawnPos;

        return productCard;
    }

    

}
