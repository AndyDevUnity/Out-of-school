using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Sprite _pauseButton;
    [SerializeField] private Sprite _unpauseButton;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void UsingPause()
    {
        if (Time.timeScale !=0)
        {
            _pausePanel.SetActive(true);
            _image.sprite = _unpauseButton;
            Time.timeScale = 0;
        }
        else
        {
            _pausePanel.SetActive(false);
            _image.sprite = _pauseButton;
            Time.timeScale = 1;
        }
    }
}
