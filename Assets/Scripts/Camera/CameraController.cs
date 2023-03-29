using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _position;

    private void Update()
    {
        _position.x = _player.position.x - 2.6f;
        _position.y = 2.9f;
        transform.position = Vector3.MoveTowards(transform.position, _position, 2.5f);
    }
}
