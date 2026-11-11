using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    [SerializeField] private HotelData[] _roomsConfigs;
    [SerializeField] private RoomSystem _panelPrefab;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _countRoomText;
    private GameObject _panel;
    private bool _isButtonClick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        _isButtonClick = true;
        StartCoroutine(SpawnNewRoom());
    }

    public IEnumerator SpawnNewRoom()
    {
        _panel = GameObject.FindWithTag("Panel");

        foreach (HotelData roomPanel in _roomsConfigs)
        {
            RoomSystem roomSystem = Instantiate(_panelPrefab, _panel.transform);

            roomSystem._nameText.text = "Имя жельца" + roomPanel.TenantName;
            roomSystem._countRoomText.text = "номер комнаты" + roomPanel.RoomNumber;


            yield return new WaitUntil(() => _isButtonClick);
        }
    }
}
