using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Burgers : MonoBehaviour
{
    [SerializeField] private TMP_InputField _playerField;
    [SerializeField] private List<BurgerData> _burgerScrObjs = new List<BurgerData>();
    [SerializeField] private TextMeshProUGUI _burgerText;
    private string _result;
    private string _playerInput;
    private string[] _inputIngridients;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       
    }

    // Update is called once per frame
    public void Cook()
    {
        _playerInput = _playerField.text;
        _inputIngridients = _playerInput.Split(", ");
        DishCalc(_inputIngridients,  out _result);
        _burgerText.text = _result;
    }

    void DishCalc(string[] playerIngs, out string _result)
    {
        _result = "Неизвестное блюдо";

        foreach (BurgerData data in _burgerScrObjs)
        {
            bool _burger = true;

            foreach (string recipe in data.Ingridients)
            {
                if (!playerIngs.Contains(recipe))
                {
                    _burger = false;
                    break;
                }
            }

            if (_burger)
            {
                _result = data.BurgerName;
                return;
            }

            
        }
       
    }

}
