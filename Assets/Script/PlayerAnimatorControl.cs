using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetAnimetorParameter(Vector2 playerxVelocity, bool groundState)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(playerxVelocity.x));
        animator.SetBool("isGround", groundState);
    }
}
