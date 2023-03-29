using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _shield;
    private ProtectiveShield _protected;

    private void Start()
    {
        _protected = _shield.GetComponent<ProtectiveShield>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Conus" && _protected._isImmortal == false)
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
