using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _forceJump;

    private Rigidbody _rigidbody;
    private Vector2 _duration = Vector2.zero;

    private float _horizontal;
    private float _vertical;
    private bool _canMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontal = _joystick.Horizontal;
        _vertical = _joystick.Vertical;
    }

    private void FixedUpdate()
    { 
        if (_horizontal != 0 && _vertical != 0)
        {
            GetDuration(out _duration);
            _canMove = true;
        }

        if (_horizontal == 0 && _vertical == 0)
            Move(ref _duration);
    }

    private void GetDuration(out Vector2 duration)
    {
        duration = -_joystick.Direction;
    }
    private void Move(ref Vector2 duration)
    {
        if (_canMove == false)
            return;

        _rigidbody.AddForce(new Vector3(_rigidbody.velocity.x, _duration.y * _forceJump, -_duration.x * _forceJump), ForceMode.Force);
        _canMove = false;
        duration = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(_duration.x, _duration.y, transform.position.z));
    }
}
