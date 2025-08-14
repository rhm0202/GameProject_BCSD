using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private PlayerAction player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��Ʈ�ڽ��� ���� �浹���� ��
        if (collision.CompareTag("enemys"))
        {
            // ���� ��ũ��Ʈ���� ������ �޼��带 ȣ��
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log($"Enemy hit: {enemy.name}");
                enemy.TakeDamage(player.attackDamage);
            }
        }
    }
}
