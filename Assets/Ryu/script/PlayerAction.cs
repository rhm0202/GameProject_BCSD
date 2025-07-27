using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerAction : MonoBehaviour
{
    // 플레이어 움직임
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        //앉기 관련 로직
        bool crouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        animator.SetBool("IsCrouching", crouching);

    }


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
            scale.x = moveInput > 0 ? -1 : 1;
            transform.localScale = scale;
        }

    }

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

}
