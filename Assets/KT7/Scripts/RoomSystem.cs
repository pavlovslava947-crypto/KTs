using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomSystem : MonoBehaviour
{
    [SerializeField] private HotelData[] _roomsConfigs;
    [SerializeField] private RoomSystemUI _panelPrefab;
    
    public HotelData CurrentData;

    private GameObject _panel;
    private bool _isButtonClick = false;
    private List<int> _roomCount = new List<int>();
   
    void Start()
    {
        _panel = GameObject.FindWithTag("Panel");

        StartCoroutine(SpawnNewRoom());
    }

    public void OnButtonClick()
    {
        _isButtonClick = true;
        
       
    }

    public IEnumerator SpawnNewRoom()
    {
        foreach (HotelData roomPanel in _roomsConfigs)
        {
            yield return new WaitUntil(() => _isButtonClick);

            RoomSystemUI roomSystemUI = Instantiate(_panelPrefab, _panel.transform);

            CurrentData = roomPanel;

            roomSystemUI.Init(roomPanel, roomSystemUI);

            _roomCount.Add(roomPanel.RoomNumber);

            _isButtonClick = false;
        }
    }

    public void PrintInfo()
    {
        int tenantWithAnimalCount = 0;
        int smithCount = 0;
        int correctRoomAmount = 0;
        int lastPetOwnerIndex = -1;
        int minRoomIndex = 0;


        for (int i = 0; i < _roomsConfigs.Length; i++)
        {
            Debug.Log($"<color=green>Комната: {_roomsConfigs[i].RoomNumber}</color>");

            if (_roomsConfigs[i].HasAnimal) tenantWithAnimalCount++;

            Debug.Log("Количество жильцов с животными: " + tenantWithAnimalCount);

            if (_roomsConfigs[i].TenantName == "Смит") smithCount++;

            Debug.Log("Количество жильцов с именем Смит: " + smithCount);

            if (_roomsConfigs[i].RoomNumber >= 0 && _roomsConfigs[i].RoomNumber <= 9) correctRoomAmount++;

            Debug.Log("количество комнат с однозначными номерами: " + correctRoomAmount);

            if (_roomsConfigs[i].RoomNumber % 3 == 0) Destroy(gameObject);

            if (_roomsConfigs[i].HasAnimal)
            {
                lastPetOwnerIndex = i;
            }

            if (_roomsConfigs[i].RoomNumber < _roomsConfigs[minRoomIndex].RoomNumber)
            {
                minRoomIndex = i;
            }

            
        }

        if (lastPetOwnerIndex != -1 && lastPetOwnerIndex != minRoomIndex)
        {
            HotelData temp = _roomsConfigs[lastPetOwnerIndex];
            _roomsConfigs[lastPetOwnerIndex] = _roomsConfigs[minRoomIndex];
            _roomsConfigs[minRoomIndex] = temp;
        }

        _roomCount.Reverse();

        Debug.Log(string.Join(", ", _roomCount));
    }
}
