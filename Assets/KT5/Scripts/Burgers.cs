using TMPro;
using UnityEngine;

public class Burgers : MonoBehaviour
{
    [SerializeField] private TMP_InputField _playerField;
    private string _playerInput;
    private string _pickles;
    private string _cheease;
    private string _meet;
    private string _ketchup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput = _playerField.text;
        Burgerss(out _pickles, out _cheease, out _meet, out _ketchup);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Burgerss(out string pickles , out string cheease , out string meet , out string ketchup)
    {
        pickles = _pickles;
        cheease = _cheease;
        meet = _meet;
        ketchup = _ketchup;
    }
}
