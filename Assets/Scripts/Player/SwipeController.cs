using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static Action<Vector2> SwipeEvent;

    private Vector2 _tapStartPosition;
    private Vector2 _swipeDelta;
    private float _minDelta = 70;

    private bool _isSwiping;
    private bool _isMobile; //для теста с пк

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (!_isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isSwiping = true;
                _tapStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
                ResetSwipe();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isSwiping = true;
                    _tapStartPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                    ResetSwipe();
            }
        }
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        if (_isSwiping)
        {
            if (!_isMobile && Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _tapStartPosition;
            else if (Input.touchCount > 0)
                _swipeDelta = (Vector2)Input.GetTouch(0).position - _tapStartPosition;
        }
        if (_swipeDelta.magnitude > _minDelta)
        {
            if (SwipeEvent != null)
            {
                if (Math.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                    SwipeEvent(_swipeDelta.x > 0 ? Vector2.left : Vector2.right);
                else
                    SwipeEvent(_swipeDelta.y > 0 ? Vector2.up : Vector2.down);
            }
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        _tapStartPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
