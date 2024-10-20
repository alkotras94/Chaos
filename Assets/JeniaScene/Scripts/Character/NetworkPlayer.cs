using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ConfigurableJoint _configurableJoint;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private Vector2 _moveInputVector = Vector2.zero;
    private bool _isJumpingButtonPressed = false;
    private bool _isGrounded = false;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private string Horizontal = "Horizontal";
    private string Vertical = "Vertical";
    private Camera _camera;


    void Start()
    {
        _camera = Camera.main;
        CameraFollow();
    }

    
    void Update()
    {
        _moveInputVector.x = Input.GetAxis(Horizontal);
        _moveInputVector.y = Input.GetAxis(Vertical);

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumpingButtonPressed = true;
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
        int numberOffHits =
            Physics.SphereCastNonAlloc(_rigidbody.position, 0.1f, transform.up * 1, _raycastHits, 0.5f);

        for (int i = 0; i < numberOffHits; i++)
        {
            if (_raycastHits[i].transform.root == transform)
                continue;

            _isGrounded = true;
            break;
        }

        if (!_isGrounded)
            _rigidbody.AddForce(Vector3.down * 10);

        float inputMagnitude = _moveInputVector.magnitude;

        if (inputMagnitude != 0)
        {
            _playerAnimation.StartAnimationWalking();
            Quaternion diseridDirection =
                Quaternion.LookRotation(new Vector3(_moveInputVector.x * -1, 0, _moveInputVector.y), transform.up);
            
            _configurableJoint.targetRotation = Quaternion.RotateTowards(_configurableJoint.targetRotation,
                diseridDirection, Time.deltaTime * 300);
            
            Vector3 localVelocifyVsForward = transform.forward * Vector3.Dot(transform.forward, _rigidbody.velocity);
            
            float localForwardVelocity = localVelocifyVsForward.magnitude;

            if (localForwardVelocity < _maxSpeed)
            {
                _rigidbody.AddForce(transform.forward * inputMagnitude * 30);
            }
        }

        if(_moveInputVector == Vector2.zero)
            _playerAnimation.StopAnim();
        
        if (_isGrounded && _isJumpingButtonPressed)
        {
            _rigidbody.AddForce(Vector3.up * 20, ForceMode.Impulse);

            _isJumpingButtonPressed = false;
        }

    }
    
    private void CameraFollow() =>
        _camera.GetComponent<CameraFollow>().Follow(gameObject);
}
