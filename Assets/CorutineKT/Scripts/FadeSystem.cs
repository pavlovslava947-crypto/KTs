using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeSystem : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _fadeImage.enabled = false;
    }

    public void OnPlayButton()
    {
        StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        _fadeImage.enabled = true;

        for(float i = 0; i <= 1; i += Time.deltaTime)
        {
            _fadeImage.color = new Color(0, 0, 0, i);

            yield return null;
        }

        SceneManager.LoadScene("CorutineKTGamePlay");

        StartCoroutine(GainImage());
    }

    private IEnumerator GainImage()
    {
        _fadeImage.enabled = true;

        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            _fadeImage.color = new Color(0, 0, 0, i);

            yield return null;
        }

        _fadeImage.enabled = false;
    }
}
