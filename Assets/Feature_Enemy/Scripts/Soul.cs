using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Soul : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private int soulValue = 1; // 소울의 가치
    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 9f;
    public IObjectPool<Soul> Pool { get; set; }

    void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        Fading(1f);

        if (rigid != null)
        {
            AddRandomForce(minForce, maxForce);
            StartCoroutine(StartBlinking());
        }
        else
        {
            Debug.LogError("Rigidbody2D component is missing.");
        }
    }

    private void AddRandomForce(float minF, float maxF)
    {
        Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(0.1f, 0.7f)).normalized;
        rigid.AddForce(randomDir * Random.Range(minF, maxF), ForceMode2D.Impulse);
        Debug.Log("Random Force Applied: ");
    }

    private IEnumerator StartBlinking()
    {
        yield return new WaitForSeconds(8f);
        StartCoroutine(Blink());
        yield return new WaitForSeconds(3f);
        if (gameObject.activeInHierarchy)
        {
            DestroySoul();
        }
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
        StopAllCoroutines();
        Pool.Release(this);
    }


    public void GetSoul()
    {
        GameManager.Instance.Soul += soulValue;
        DestroySoul();
    }
}
