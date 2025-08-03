using UnityEngine;
using UnityEngine.UI; // UI ������Ʈ ���

public class PlayerUIManager : MonoBehaviour
{
    public Slider hpBar; // Inspector���� ������ HP ��

    public void InitHPUI(int max, int current)
    {
        hpBar.maxValue = max;
        hpBar.value = current;
    }

    public void UpdateHPBar(int currentHP)
    {
        hpBar.value = currentHP;
    }
}