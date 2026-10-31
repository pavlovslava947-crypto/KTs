using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBurger", menuName = "Scriptable Objects/BurgerData")]
public class BurgerData : ScriptableObject
{
    [Header("Имя бургера")]
    [SerializeField] private string _burgerName = "Новый бургер";
    [Header("Ингридиенты")]
    [SerializeField] private string[] _ingridients;

    public string BurgerName => _burgerName;
    public string[] Ingridients => _ingridients;

}
