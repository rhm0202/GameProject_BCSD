using UnityEngine;

public class Enemy_Grounded : Enemy
{
    private bool isWalking = false;
    private bool isChasing = false;

    private int direction = 1;

    public override void Move()
    {
        int direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = moveSpeed * direction;

        isWalking = true;
    }

    public override void Chase()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);
        if (target != null)
        {
            isChasing = true;

            if( isFacingRight && target.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if (!isFacingRight && target.transform.position.x > transform.position.x)
            {
                Flip();
            }
        }
        Move();
    }

    bool IsGroundAhead()
    {
        Vector2 frontPoint = new Vector2(rigid.position.x + (isFacingRight ? 0.5f : -0.5f), rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontPoint, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }

    void Update()
    {
        stateMachine.Update();
        if (!IsGroundAhead())
        {
            Flip();
        }
    }
}
