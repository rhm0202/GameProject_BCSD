using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트 사용

public class PlayerUIManager : MonoBehaviour
{
    public Slider hpBar; // Inspector에서 연결할 HP 바

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