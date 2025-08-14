using UnityEngine;

public class Enemy_Grounded : Enemy
{

    private int direction = 1;
    [SerializeField] private float chasingSpeed = 2f;
    [SerializeField] protected float patrolSpeed = 1f;


    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;

    }

    public override bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);

        if (target != null)
        {
            Vector2 dirToPlayer = target.transform.position - transform.position;
            if ((dirToPlayer.x > 0 && isFacingRight) || (dirToPlayer.x < 0 && !isFacingRight))
            {
                player = target.GetComponent<PlayerAction>();
                Debug.Log("�÷��̾ ���� �þ� ���� ���� �ֽ��ϴ�.");
                return true;
            }
        }
        return false;
    }

    public override void Chase()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);
        if (target != null)
        {
            applyedSpeed = chasingSpeed;

            if ( isFacingRight && target.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if (!isFacingRight && target.transform.position.x > transform.position.x)
            {
                Flip();
            }
        }
        else
        {
            isChasingPlayer = false;
        }
    }

    public override void Patrol()
    {
        applyedSpeed = patrolSpeed;
        if (!IsGroundAhead())
        {
            Flip();
        }
    }

    private bool IsGroundAhead()
    {
        Vector2 frontPoint = new Vector2(rigid.position.x + (isFacingRight ? 0.5f : -0.5f), rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontPoint, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }

    void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
