using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private PlayerAction player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 공격 히트박스가 적과 충돌했을 때
        if (collision.CompareTag("enemys"))
        {
            // 적의 스크립트에서 데미지 메서드를 호출
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log($"Enemy hit: {enemy.name}");
                enemy.TakeDamage(player.attackDamage);
            }
        }
    }
}
