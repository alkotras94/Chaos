using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Walking = "Walking";

    public void StartAnimationWalking()
    {
        _animator.SetBool(Walking, true);
    }

    public void StopAnim()
    {
        _animator.SetBool(Walking, false);
    }
}
