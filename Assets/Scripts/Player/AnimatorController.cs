using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CharacterController>();
        SwipeController.SwipeEvent += JumpAnimation;
        SwipeController.SwipeEvent += SlideAnimation;
    }

    private void JumpAnimation(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            _animator.SetBool("run", true);
            _animator.SetTrigger("jump");
        }
    }

    private void SlideAnimation(Vector2 direction)
    {
        if (direction == Vector2.down)
        {
            _collider.height = 0.9f;
            _animator.SetTrigger("slide");
            _animator.SetBool("run", true);
        }
        else
        {
            _collider.height = 1.5f;
        }
    }
}
