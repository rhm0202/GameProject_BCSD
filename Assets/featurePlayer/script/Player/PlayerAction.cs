using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerAction : MonoBehaviour
{
    //플레이어 정보 모음
    [SerializeField] private PlayerResource playerResource;

    // 플레이어 움직임
    public float speed;
    public float jumpForce;

    // 점프를 위한 바닥 체크
    public Transform groundCheck;
    public LayerMask groundLayer;

    // 필요한 인스펙터..?
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    //플레이어 상태 확인
    private bool isAttact;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = playerResource.speed;
        jumpForce = playerResource.jumpForce;
        //sr = GetComponent<SpriteRenderer>();
        //lastPosition = transform.position;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //TrackIdleTime(stateInfo);

        float moveInput = Input.GetAxisRaw("Horizontal");

        Move(moveInput);

        Jumpping();

        crouching();

        Attact();

    }

    // 좌우 움직임
    void Move(float moveInput)
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        animator.SetBool("IsMoving", true);
        

        if (moveInput == 0)
        {
            animator.SetBool("IsMoving", false);
            Debug.Log("걷는 중 아님");
        }

        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveInput > 0 ? -1 : 1);
            transform.localScale = scale;
        }

    }

    // 점프
    void Jumpping()
    {
        Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log($"isGrounded: {isGrounded}");

        // 기본 상태
        isGrounded = false;

        if (hit != null)
        {
            isGrounded = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Debug.Log("뛰는 중");
        }
        else
        {
            Debug.Log("뛰는 중 아님");
        }

        animator.SetBool("IsJumping", !isGrounded);
    }

    // 앉기
    void crouching()
    {
        //앉기 관련 로직
        bool crouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        animator.SetBool("IsCrouching", crouching);
    }

    // 공격
    void Attact()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !isAttact)
        {
            //PlayerResource.Attact();
        }
    }

}
