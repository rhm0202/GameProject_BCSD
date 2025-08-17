using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private int damage = 6;

    private Vector2 startPosition;
    private Vector2 direction;

    public void Initialize(Vector2 startPosition, Vector2 direction)
    {
        this.startPosition = startPosition;
        this.direction = direction.normalized;
        transform.position = startPosition;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAction>().TakeDamage(damage, transform.position);
            Destroy(gameObject);
        }
    }
}
