using UnityEngine;

public class AcceptInfo : MonoBehaviour
{
    [SerializeField] private GameObject _infoScore;
    public void BackToGame()
    {
        Time.timeScale = 1;
        _infoScore.SetActive(false);
    }
}
