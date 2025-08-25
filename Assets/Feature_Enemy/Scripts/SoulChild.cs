using UnityEngine;


// 플레이어가 소울(트리거)에 닿았는지만 확인하는 스크립트
public class SoulChild : MonoBehaviour
{
    private Soul soul;

    private void Start()
    {
        soul = GetComponentInParent<Soul>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (soul != null && soul.Pool != null)
            {
                soul.GetSoul();
            }
        }
    }
}
