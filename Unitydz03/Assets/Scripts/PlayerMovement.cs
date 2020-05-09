using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.MovePosition(playerRigidbody.position + Vector2.left * _runSpeed * Time.fixedDeltaTime);
            playerSpriteRenderer.flipX = true;
            playerAnimator.SetInteger("State", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.MovePosition(playerRigidbody.position + Vector2.right * _runSpeed * Time.fixedDeltaTime);
            playerSpriteRenderer.flipX = false;
            playerAnimator.SetInteger("State", 1);
        }
        else
        {
            playerAnimator.SetInteger("State", 0);
        }
    }
}
