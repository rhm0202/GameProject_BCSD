using UnityEngine;

public class EnemyAttackHItbox : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAction player = collision.GetComponent<PlayerAction>();
            if (player != null)
            {
                player.TakeDamage(enemy.EnemyDamage, enemy.transform.position);
            }
        }
    }
}
