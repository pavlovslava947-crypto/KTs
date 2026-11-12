using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomSystemUI : MonoBehaviour
{
    [SerializeField] private Toggle _petToggle;
    private HotelData _hotelData;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _countRoomText;


    private void Start()
    {
        _petToggle.SetIsOnWithoutNotify(_hotelData.HasAnimal);

        _petToggle.onValueChanged.AddListener(OnPetToggleChanged);
    }

    public void OnPetToggleChanged(bool isChecked)
    {
        _hotelData.HasAnimal = isChecked;
    }

    public void Init(HotelData hotelData, RoomSystemUI roomSystem)
    {
        _hotelData = hotelData;
        roomSystem._nameText.text = "Имя жильца " + hotelData.TenantName;
        roomSystem._countRoomText.text = "номер комнаты " + hotelData.RoomNumber;
    }
}
