using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;

    private const string CollectResources = nameof(CollectResources);

    public void StartAnimationRuning()
    {
        _animator.SetFloat("Speed", _characterController.velocity.sqrMagnitude, 0.1f, Time.deltaTime);
    }
}
