using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject uiImage;
    [SerializeField] private GameObject _levelButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void PlayButtonOnClick()
    {
        playButton.SetActive(false);
        uiImage.SetActive(true);
        exitButton.SetActive(true);
        _levelButton.SetActive(true);
    }

    public void ExitButtonOnClick()
    {
        exitButton.SetActive(false);
        uiImage.SetActive(false);
        playButton.SetActive(true);
        _levelButton.SetActive(false);
    }
}
