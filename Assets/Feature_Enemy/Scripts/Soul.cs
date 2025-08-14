using System.Collections;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 9f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (rigid != null)
        {
            Debug.Log("Soul Rigidbody2D found, applying random force.");
            AddRandomForce(minForce, maxForce);
            Invoke("StartBlinking", 4f);
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
        Invoke("DestroySoul", 2.5f);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
