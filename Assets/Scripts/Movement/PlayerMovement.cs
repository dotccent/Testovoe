using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private bool facingRight = true;    // булевая переменная для проверки направления взгляда персонажа
    private bool jumping = false;   // булевая переменная для проверки нахождения персонажа в состоянии прыжка

    [SerializeField] private Rigidbody2D _rb;
    // переменные для проверки нахождения игрока на земле
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    public float speed = 10f;   // скорость
    public float jumpPower = 10.0f; // сила прыжка
    public float speedMultiplier = 1.0f;    // множитель ускорителя
    public Animator _animator;  // переменная для смены спрайтов анимаций

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");  // задаем направление движения
        _animator.SetFloat("isMoving", Mathf.Abs(horizontalMove));  // меняем спрайт анимации в зависимости от направления движения игрока

        // прыжок игрока
        // если игрок нажал кнопку прыжка и находится на земле, то меняем его траекторию движения по оси Y
        if (Input.GetKey(KeyCode.W)  && isGrounded() || Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            jumping = true;
            _animator.SetBool("isJumping", jumping);    // меняем спрайты анимации на спрайты анимации прыжка
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpPower);
        }
        // если координаты персонажа по оси Y больше нуля и игрок нажимает на кнопку прыжка, то уменьшаем координаты в два раза, пока игрок не приземлится
        else if (Input.GetKeyUp(KeyCode.W) && _rb.linearVelocity.y > 0f || Input.GetKeyUp(KeyCode.UpArrow) && _rb.linearVelocity.y > 0f)
        {
            jumping = false;
            _animator.SetBool("isJumping", jumping);    // меняем спрайты анимации на спрайты анимации простоя или бега
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.y * 0.5f);
        }

        flipCharacter();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(horizontalMove * speed * speedMultiplier, _rb.linearVelocity.y);   // задаем скорость движения игрока
    }

    // создаем круг, который будет проверять находится игрок на земле
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);  
    }

    // отражение спрайта игрока в зависимости от направления движения
    // если игрок движется вправо, но спрайт героя смотрит влево (facingRight = false), то спрайт необходимо отразить вправо,
    // если игрок движется влево, но спрайт смотрит вправо (facingRight = true), то спрайт необходимо отразить влево.
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

    // функция ускорения персонажа
    public void SpeedBoost(float multiplier)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    // корутина для ограничения времени ускорения персонажа после подбора зелья скорости на 2 секунды
    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(2);
        speedMultiplier = 1.0f;
    }
}
