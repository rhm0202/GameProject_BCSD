using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트 사용

public class PlayerUIManager : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP = 100;

    public Slider hpBar; // Inspector에서 연결할 HP 바

    void Start()
    {
        // 시작할 때 최대 체력으로 바 세팅
        if (hpBar != null)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
    }

    void Update()
    {
        // 예시) H 키로 데미지 입히기 (테스트)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        if (hpBar != null)
            hpBar.value = currentHP;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;

        if (hpBar != null)
            hpBar.value = currentHP;
    }
}