using System.Collections;
using UnityEngine;

public class ProtectiveShield : MonoBehaviour, Interaction
{
    [SerializeField] private GameObject _infoShield;
    [SerializeField] private GameObject _timeShield;
    private bool _showInfo = true;
    public bool _isImmortal = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            if (_showInfo)
            {
                Time.timeScale = 0;
                _infoShield.SetActive(true);
                _showInfo = false;
            }
            StartCoroutine(EffectAction());
            Destroy(other.gameObject);
        }
    }

    public IEnumerator EffectAction()
    {
        _isImmortal = true;
        _timeShield.SetActive(true);
        yield return new WaitForSeconds(10);
        _isImmortal = false;
        _timeShield.SetActive(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Conus")
        {
            if (_isImmortal)
                Destroy(hit.gameObject);
        }
    }
}
