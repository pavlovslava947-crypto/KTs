using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _time = 4f;
    [SerializeField] private Image _buttonImage;
    private Color _baseColor = Color.white;
    private bool _isContinue = true;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void OnFireAbilityButton()
    {
        if (!_isContinue) return;
        Color fireColor = Color.orange;
        
        StartCoroutine(Ability(fireColor, 2f));
    }

    public void OnWaterAbilityButton()
    {
        if (!_isContinue) return;
        Color waterColor = Color.blue;

        StartCoroutine(Ability(waterColor, 3f));
    }

    public void OnGroundAbilityButton()
    {
        if (!_isContinue) return;
        Color waterColor = Color.brown;

        StartCoroutine(Ability(waterColor, 5f));
    }
    private IEnumerator Ability(Color color, float cooldown)
    {
        _time = cooldown;

        _buttonImage.color = color;

        _isContinue = false;

        yield return new WaitForSeconds(_time);

        _buttonImage.color = _baseColor;

        yield return new WaitForSeconds(_time);

        _isContinue = true;
    }
}
