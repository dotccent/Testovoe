using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private bool facingRight = true;    // ������� ���������� ��� �������� ����������� ������� ���������
    private bool jumping = false;   // ������� ���������� ��� �������� ���������� ��������� � ��������� ������

    [SerializeField] private Rigidbody2D _rb;
    // ���������� ��� �������� ���������� ������ �� �����
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    public float speed = 10f;   // ��������
    public float jumpPower = 10.0f; // ���� ������
    public float speedMultiplier = 1.0f;    // ��������� ����������
    public Animator _animator;  // ���������� ��� ����� �������� ��������

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");  // ������ ����������� ��������
        _animator.SetFloat("isMoving", Mathf.Abs(horizontalMove));  // ������ ������ �������� � ����������� �� ����������� �������� ������

        // ������ ������
        // ���� ����� ����� ������ ������ � ��������� �� �����, �� ������ ��� ���������� �������� �� ��� Y
        if (Input.GetKey(KeyCode.W)  && isGrounded() || Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            jumping = true;
            _animator.SetBool("isJumping", jumping);    // ������ ������� �������� �� ������� �������� ������
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpPower);
        }
        // ���� ���������� ��������� �� ��� Y ������ ���� � ����� �������� �� ������ ������, �� ��������� ���������� � ��� ����, ���� ����� �� �����������
        else if (Input.GetKeyUp(KeyCode.W) && _rb.linearVelocity.y > 0f || Input.GetKeyUp(KeyCode.UpArrow) && _rb.linearVelocity.y > 0f)
        {
            jumping = false;
            _animator.SetBool("isJumping", jumping);    // ������ ������� �������� �� ������� �������� ������� ��� ����
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.y * 0.5f);
        }

        flipCharacter();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(horizontalMove * speed * speedMultiplier, _rb.linearVelocity.y);   // ������ �������� �������� ������
    }

    // ������� ����, ������� ����� ��������� ��������� ����� �� �����
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);  
    }

    // ��������� ������� ������ � ����������� �� ����������� ��������
    // ���� ����� �������� ������, �� ������ ����� ������� ����� (facingRight = false), �� ������ ���������� �������� ������,
    // ���� ����� �������� �����, �� ������ ������� ������ (facingRight = true), �� ������ ���������� �������� �����.
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

    // ������� ��������� ���������
    public void SpeedBoost(float multiplier)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    // �������� ��� ����������� ������� ��������� ��������� ����� ������� ����� �������� �� 2 �������
    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(2);
        speedMultiplier = 1.0f;
    }
}
