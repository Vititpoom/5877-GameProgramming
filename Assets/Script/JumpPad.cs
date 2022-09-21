using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private BoxCollider2D jumpPadCollider;
    [SerializeField] private float bounce = 5f;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      PlayerControl playerControl = collision.gameObject.GetComponentInChildren<PlayerControl>();
        playerControl.rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

    }
}
