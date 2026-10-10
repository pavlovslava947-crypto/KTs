using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetLevelNumber : MonoBehaviour
{
    [SerializeField] private bool _randomStarsGen = false;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject _starOne;
    [SerializeField] private GameObject _starTwo;
    [SerializeField] private GameObject _starThree;
    private int _starRand;

    private void Start()
    {
        // Находим текст внутри кнопки
        _levelText = GetComponentInChildren<TMP_Text>();



        // transform.GetSiblingIndex() возвращает индекс объекта в иерархии (начиная с 0)
        // Прибавляем 1, чтобы первый уровень был под номером 1, а не 0
        int currentLevelNumber = transform.GetSiblingIndex() + 1;

        _levelText.text = currentLevelNumber.ToString();
        gameObject.name = "Level Button " + currentLevelNumber;

        if( _randomStarsGen == true)
        {
            _starRand = Random.Range(0, 4);

            if (_starRand == 1)
            {
                _starOne.SetActive(true);
            }

            if (_starRand == 2)
            {
                _starOne.SetActive(true);
                _starTwo.SetActive(true);
            }

            if (_starRand == 3)
            {
                _starOne.SetActive(true);
                _starTwo.SetActive(true);
                _starThree.SetActive(true);
            }

            else if (_starRand == 4 || _starRand == 0)
            {
                _starOne.SetActive(false);
                _starTwo.SetActive(false);
                _starThree.SetActive(false);
            }


        }

        

        

        
        if( _randomStarsGen == false )
        {
            _starOne.SetActive(true);
            _starTwo.SetActive(true);
            _starThree.SetActive(true);
        }

    }

   
}
