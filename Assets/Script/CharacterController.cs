using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _moveSpeed = 5f;

    void FixedUpdate()
    {
        Vector3 camForward = _cameraTransform.forward;
        Vector3 camRight = _cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir =
            camForward * _joystick.Vertical +
            camRight * _joystick.Horizontal;

        _rigidbody.velocity = new Vector3(
            moveDir.x * _moveSpeed,
            _rigidbody.velocity.y,
            moveDir.z * _moveSpeed
        );

        if (moveDir.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }
    }
}
