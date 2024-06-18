using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorWrapper : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetParameter(string parameter) => _animator.SetBool(parameter, true);
    public void ResetParameter(string parameter) => _animator.SetBool(parameter, false);
}
