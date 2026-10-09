using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    [SerializeField] private GameObject _levelButton;
    [SerializeField] private GameObject _lockLevelButton;
    [SerializeField] private int _levelButtonValue = 1;
    [SerializeField] private int _lockLevelValue = 1;
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _exitButton;
    private List<GameObject> _spawnedButtons = new List<GameObject>();
    private bool _hasSpawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (_menu.activeInHierarchy && _exitButton.activeInHierarchy && !_hasSpawned)
        {
            SpawnLevelButton();
        }

        if (!_menu.activeInHierarchy && _hasSpawned)
        {
            ClearLevelButtons();
        }
    }

    void SpawnLevelButton()
    {
        _hasSpawned = true;
        _levelButton.SetActive(true);

        for (int i = 0; i < _levelButtonValue; i++)
        {


            GameObject _spawnObject = Instantiate(_levelButton, _panel);
           

            _spawnedButtons.Add(_spawnObject);
            

        }

        for (int i = 0; i < _lockLevelValue; i++)
        {


            
            GameObject _spawnLockLevels = Instantiate(_lockLevelButton, _panel);

           
            _spawnedButtons.Add(_spawnLockLevels);

        }



    }

    void ClearLevelButtons()
    {
        _hasSpawned = false;

        foreach (GameObject button in _spawnedButtons)
        {
            Destroy(button);
        }

        _spawnedButtons.Clear();
    }


}
