using UnityEngine;

[CreateAssetMenu(fileName = "NewTenant", menuName = "Scriptable Objects/HotelData")]
public class HotelData : ScriptableObject
{
    [Header("Настройки Жильца")]
    [SerializeField] private int _roomNumber;
    [SerializeField] private string _tenantName;
    [SerializeField] private bool _hasAnimal;

    public int RoomNumber => _roomNumber;
    public string TenantName => _tenantName;
    public bool HasAnimal => _hasAnimal;
}
