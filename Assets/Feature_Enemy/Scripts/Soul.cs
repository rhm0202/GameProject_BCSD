using System.Collections;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int soulValue = 1; // 소울의 가치
    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 9f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (rigid != null)
        {
            AddRandomForce(minForce, maxForce);
            Invoke("StartBlinking", 8f);
        }
    }

    void AddRandomForce(float minF, float maxF)
    {
        Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(0.1f, 0.7f)).normalized;
        rigid.AddForce(randomDir * Random.Range(minF, maxF), ForceMode2D.Impulse);
    }

    private void StartBlinking()
    {
        StartCoroutine(Blink());
        Invoke("DestroySoul", 3f);
    }
    private IEnumerator Blink()
    {
        while(true)
        {
            Fading(0f);
            yield return new WaitForSeconds(0.13f);
            Fading(1f);
            yield return new WaitForSeconds(0.13f);
        }
    }

    private void Fading(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    private void DestroySoul()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Soul += soulValue;
            DestroySoul();
        }
    }
}
