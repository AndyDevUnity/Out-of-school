using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private TMP_Text _playerScore;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = _player.position;
    }
    private void FixedUpdate()
    {
        _playerScore.text = (int)Vector3.Distance(_startPosition, _player.position) + "m";
    }
}
