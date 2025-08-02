using UnityEngine;

public class Enemy_Grounded : Enemy
{
    private bool isWalking = false;

    protected override void move()
    {
        int direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = moveSpeed * direction;

        isWalking = true;
    }

    bool IsGroundAhead()
    {
        Vector2 frontPoint = new Vector2(rigid.position.x + (isFacingRight ? 0.5f : -0.5f), rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontPoint, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }

    void FixedUpdate()
    {
        move();
        if (!IsGroundAhead())
        {
            Flip();
        }
    }
}
