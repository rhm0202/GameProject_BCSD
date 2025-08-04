using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    //플레이어 정보 모음
    [SerializeField]
    private PlayerResource playerResource;

    //플레이어 UI 조작
    [SerializeField]
    private PlayerUIManager playerUIManager;

    //플레이어 스테이터스 게임 플레이 도중에 받은 버프 or 스킬로 변경 가능함

    //플레이어 체력
    public int maxHP;
    public int currentHP;

    //플레이어 이동속도
    public float speed;

    //플레이어 점프력
    public float jumpForce;

    //플레이어 공격속도
    public float attactSpeed;
    [SerializeField] private float attacksuspendTime = 0.2f; // 공격 유지 시간
    [SerializeField] private float attackdelayTime;          // 공격 선 딜레이 시간

    //플레이어 공격력
    public float attackDamage;

    // 점프를 위한 바닥 체크
    public Transform groundCheck;
    public LayerMask groundLayer;

    // 필요한 인스펙터..?
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    //플레이어 상태 확인
    private bool isAttack = false;
    private float lastAttackTime = 0f;
    private bool isCrouching = false;
    private bool isKnockbacking = false;    // 넉백 중인지 확인(넉백 중에는 다른 힘을 받지 않도록)

    // 플레이어 공격 판정 히트박스 오브젝트
    [SerializeField] private GameObject attackHitbox;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHP = playerResource.maxHP;
        currentHP = playerResource.currentHP;
        speed = playerResource.speed;
        jumpForce = playerResource.jumpForce;
        attactSpeed = playerResource.attackSpeed;
        attackDamage = playerResource.attackDamage;
        playerUIManager.InitHPUI(maxHP, currentHP);
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //TrackIdleTime(stateInfo);

        float moveInput = Input.GetAxisRaw("Horizontal");

        if (!isKnockbacking)
        {
            Move(moveInput);

            Jumpping();

            crouching();

            Attack();
        }

        //데미지 피해 테스트
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10, Vector2.zero);
        }

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
    void Attack()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !isAttack)
        {
            animator.SetTrigger("IsAttact");
            isAttack = true;
            Invoke("EnableHitbox", attackdelayTime);
            StartCoroutine(AttackCooldownCoroutine());
        }
    }
    private void EnableHitbox()
    {
        attackHitbox.SetActive(true);
        Invoke("DisableHitbox", attacksuspendTime);
    }
    private void DisableHitbox()
    {
        attackHitbox.SetActive(false);
    }
    IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(1f / attactSpeed);
        isAttack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemys"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(10, collision.transform.position); // 예시로 10의 데미지를 받음
        }
    }

    public void TakeDamage(int amount, Vector2 targetPos)
    {
        currentHP -= amount;
        playerUIManager.UpdateHPBar(currentHP);

        if (currentHP < 0) currentHP = 0;

        if (currentHP == 0)
        {
            GameOver();
        }
        else
        {
            Debug.Log($"Player took {amount} damage. Current HP: {currentHP}");
            int direction = (transform.position.x < targetPos.x) ? 1 : -1;
            Knockback(direction);
        }
    }
    private void Knockback(int direction)
    {
        isKnockbacking = true;
        rb.AddForce(new Vector2(direction * 25, 7), ForceMode2D.Impulse);
        Invoke("ResetKnockback", 0.3f);
    }
    private void ResetKnockback()
    {
        isKnockbacking = false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
    }

    void GameOver()
    {
        currentHP = maxHP;
        SceneManager.LoadScene("GameOver");
    }

}
