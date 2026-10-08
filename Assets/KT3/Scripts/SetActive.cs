using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject uiImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playButton.activeInHierarchy)
        {
            uiImage.SetActive(true);
        }
    }
}
