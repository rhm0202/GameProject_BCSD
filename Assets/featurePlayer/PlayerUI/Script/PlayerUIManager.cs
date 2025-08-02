using UnityEngine;
using UnityEngine.UI; // UI ������Ʈ ���

public class PlayerUIManager : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP = 100;

    public Slider hpBar; // Inspector���� ������ HP ��

    void Start()
    {
        // ������ �� �ִ� ü������ �� ����
        if (hpBar != null)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
    }

    void Update()
    {
        // ����) H Ű�� ������ ������ (�׽�Ʈ)
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