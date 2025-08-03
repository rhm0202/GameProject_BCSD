using UnityEngine;
using UnityEngine.UI; // UI ������Ʈ ���
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public Slider hpBar; // Inspector���� ������ HP ��
    public TMP_Text hpText;

    public int maxHP;
    public int currentHP;
    public int coin;
    public int soul;

    public void InitHPUI(int max, int current)
    {
        maxHP = max;
        currentHP = current;

        hpBar.maxValue = max;
        hpBar.value = current;

        hpText.text = $"{current} / {max}";
    }

    public void UpdateHPBar(int currentHP)
    {
        this.currentHP = currentHP;
        hpBar.value = currentHP;
        hpText.text = $"{currentHP} / {maxHP}";
    }
}