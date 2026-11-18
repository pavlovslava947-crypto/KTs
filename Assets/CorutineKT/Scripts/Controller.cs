using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _interval = 4f;
    private bool _isContinue = true;

    public void OnAbilityButton()
    {
        if (!_isContinue) return;
        Color fireColor = Color.orange;
        StartCoroutine(Ability(fireColor));
    }
    private IEnumerator Ability(Color color)
    {

        Image abilityButton = gameObject.GetComponent<Image>();

        abilityButton.color = color;

        yield return new WaitForSeconds(_interval);
    }
}
