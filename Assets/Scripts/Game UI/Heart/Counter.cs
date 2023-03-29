using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private int _heartsScore;
    [SerializeField] private TMP_Text _scoreText;
    public int _multiply = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heart")
        {
            _heartsScore += _multiply;
            _scoreText.text = _heartsScore.ToString();
            Destroy(other.gameObject);
        }
    }
}