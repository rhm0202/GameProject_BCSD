using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


// �������� 1�� ����
// ��ȸ�ϸ� ���� �ð����� ��� ����
// �÷��̾��� ��ġ�� ���� ����
public class Boss_Stage1 : Enemy
{
    private int direction = 1;
    public new Boss1SM stateMachine;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private GameObject shadowPrefab;     // ���� ���� �� �׸���
    [SerializeField] private ParticleSystem dust;

    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isResting = false; // ���� �� �� �� true

    public void StartBossFight()
    {
        player = FindAnyObjectByType<PlayerAction>().GetComponent<PlayerAction>();
        isFacingRight = false;
        applyedSpeed = moveSpeed;
    }

    public override void Chase()
    {
        if (player == null)
        {
            return;
        }

        if (isFacingRight && player.transform.position.x < transform.position.x)
        {
            Flip();
        }
        else if (!isFacingRight && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    public override bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);
        if(target != null)
        {
            return true;
        }
        return false;
    }


    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;
    }

    public override void Patrol()
    {
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss1SM(this);
    }

    public void NormalAttack()
    {
        StartCoroutine(NAttackCoroutine());
    }
    public void JumpAttack()
    {
        StartCoroutine(JAttackCoroutine());
    }

    private IEnumerator NAttackCoroutine()
    {
        yield return new WaitForSeconds(0.75f); // ���� ������
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.6f); // ���� �� ������
        attackHitbox.SetActive(false);
        isAttacking = false;
    }

    private IEnumerator JAttackCoroutine()
    {
        float shadowPosY = transform.position.y - 1;

        ChangeAnimation("Attack");
        ChangeAnimationSpeed(0.25f);
        yield return new WaitForSeconds(0.95f);
        rigid.linearVelocityY = 700f;
        ChangeAnimationSpeed(1f);

        while (true)
        {
            if (transform.position.y >= 500)
            {
                rigid.linearVelocityY = -10f;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        float playerPosX = player.transform.position.x;
        transform.position = new Vector2(playerPosX, transform.position.y);

        Vector2 shadowPos = new Vector2(playerPosX, shadowPosY);
        GameObject shadow = Instantiate(shadowPrefab, shadowPos, Quaternion.identity);
        

        while (true)
        {

            if (transform.position.y - player.transform.position.y < 210)
            {
                ChangeAnimation("Attack");
                Chase();
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        while (true)
        {
            if (rigid.linearVelocityY >= 0)
            {
                Destroy(shadow);
                dust.Play();
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (!isAttacking && !isResting)
        {
            Move();
        }
    }
}
