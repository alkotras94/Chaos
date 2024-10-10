using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private IInputServices _inputServices;
    private Camera _camera;

    private void Awake()
    {
        _inputServices = Game.InputServisec;
    }
    void Start()
    {
        _camera = Camera.main;
        CameraFollow();
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (_inputServices.Axis.sqrMagnitude > 0.001f)
        {
            movementVector = _camera.transform.TransformDirection(_inputServices.Axis);
            movementVector.y = 0;
            movementVector.Normalize();

            transform.forward = movementVector;
        }
        movementVector += Physics.gravity;

        _characterController.Move(_speed * movementVector * Time.deltaTime);
        _playerAnimation.StartAnimationRuning();
    }

    private void CameraFollow() =>
        _camera.GetComponent<CameraFollow>().Follow(gameObject);

}
