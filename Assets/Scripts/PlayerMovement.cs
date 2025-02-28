using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    public float speed = 10f;
    public float jumpPower = 10.0f;
    private bool facingRight = true;
    private bool jumping = false;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    public Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");  // задаем начальную скорость движения
        _animator.SetFloat("isMoving", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.W) && isGrounded())
        {
            jumping = true;
            _animator.SetBool("isJumping", jumping);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpPower);
        }
        else if (Input.GetKeyUp(KeyCode.W) && _rb.linearVelocity.y > 0f)
        {
            jumping = false;
            _animator.SetBool("isJumping", jumping);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.y * 0.5f);
        }

        flipCharacter();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(horizontalMove * speed, _rb.linearVelocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void flipCharacter()
    {
        if (facingRight && horizontalMove < 0f || !facingRight && horizontalMove > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
