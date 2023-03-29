using UnityEngine;
using System.Collections;

public class DoubleHearts : MonoBehaviour, Interaction
{
    [SerializeField] private GameObject _infoHearts;
    [SerializeField] private GameObject _timeHearts;
    private bool _showInfo = true;
    private Counter _score;

    private void Start()
    {
        _score = GetComponent<Counter>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Multiply")
        {
            if (_showInfo)
            {
                Time.timeScale = 0;
                _infoHearts.SetActive(true);
                _showInfo = false;
            }
            StartCoroutine(EffectAction());
            Destroy(other.gameObject);
        }
    }

    public IEnumerator EffectAction()
    {
        _score._multiply = 2;
        _timeHearts.SetActive(true);
        yield return new WaitForSeconds(15);
        _score._multiply = 1;
        _timeHearts.SetActive(false);
    }
}
