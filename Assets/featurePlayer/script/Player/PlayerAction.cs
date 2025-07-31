using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerAction : MonoBehaviour
{
    //플레이어 정보 모음
    [SerializeField] private PlayerResource playerResource;
    //플레이어 스테이터스 게임 플레이 도중에 받은 버프 or 스킬로 변경 가능함
    //플레이어 체력
    private int maxHP;
    public int currentHP;

    //플레이어 이동속도
    public float speed;

    //플레이어 점프력
    public float jumpForce;

    //플레이어 공격속도
    public float attactSpeed;

    //플레이어 공격력
    public float attactDamage;

    // 점프를 위한 바닥 체크
    public Transform groundCheck;
    public LayerMask groundLayer;

    // 필요한 인스펙터..?
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    //플레이어 상태 확인
    private bool isAttact = false;
    private float lastAttackTime = 0f;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHP = playerResource.maxHP;
        currentHP = playerResource.currentHP;
        speed = playerResource.speed;
        jumpForce = playerResource.jumpForce;
        attactSpeed = playerResource.attactSpeed;
        attactDamage = playerResource.attactDamage;
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
        float moveSpeed = speed;
        
        if (isCrouching) 
        {
            moveSpeed *= 0.3f;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        animator.SetBool("IsMoving", true);
        

        if (moveInput == 0)
        {
            animator.SetBool("IsMoving", false);
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
        isCrouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        animator.SetBool("IsCrouching", isCrouching);
    }

    // 공격
    void Attact()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !isAttact)
        {
            playerResource.Attact();
            animator.SetTrigger("IsAttact");
            isAttact = true;
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(1f / attactSpeed);
        isAttact = false;
    }

}
