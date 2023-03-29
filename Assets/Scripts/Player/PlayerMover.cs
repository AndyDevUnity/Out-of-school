using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Run")]
    private CharacterController _playerController;
    private float _moveSpeed = 2;
    private const float _maxSpeed = 100;
    private Vector3 _move, _velocity;

    [Header("SwitchLane")]
    private int _lanePosition = 1;
    private float _laneOffset = 2.7f;

    [Header("Gravitation")]
    [SerializeField] private Transform _checkGround;
    [SerializeField] private LayerMask _groundLayer;
    private float _groundDistance = 0.4f;
    private float _gravity = -18f;
    [SerializeField] private bool _isGround = true;
    [SerializeField] private float _jumpForce = 4.8f;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
        SwipeController.SwipeEvent += OnSWipe;
        StartCoroutine(IncreaseSpeed());
    }

    private void Update()
    {
        Run();
        CheckGround();
    }

    private void Run()
    {
        _move = transform.forward * Time.deltaTime;
        _playerController.Move(_move * _moveSpeed);
    }

    private void OnSWipe(Vector2 direction)
    {
        if (direction == Vector2.left && _lanePosition < 2)
        {
            _playerController.Move(Vector3.back * _laneOffset);
            _lanePosition++;
        }
        else if (direction == Vector2.right && _lanePosition > 0)
        {
            _playerController.Move(Vector3.forward * _laneOffset);
            _lanePosition--;
        }
        else if (direction == Vector2.up && _isGround)
        {
            _velocity = transform.up * _jumpForce;
            _playerController.Move(_velocity * Time.deltaTime);
        }
    }

    private void CheckGround()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _playerController.Move(_velocity * Time.deltaTime);

        _isGround = Physics.CheckSphere(_checkGround.position, _groundDistance, _groundLayer);
        if (_velocity.y < 0 && _isGround)
            _velocity.y = -2f;
    }

    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(3);
        if (_moveSpeed < _maxSpeed)
        {
            _moveSpeed += 0.5f;
            StartCoroutine(IncreaseSpeed());
        }
    }
}
