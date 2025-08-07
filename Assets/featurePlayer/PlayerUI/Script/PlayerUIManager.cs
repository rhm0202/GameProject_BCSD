using UnityEngine;
using UnityEngine.UI; // UI ������Ʈ ���
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar; // Inspector���� ������ HP ��
    [SerializeField]
    private TMP_Text hpText;
    [SerializeField]
    private Canvas settingUI;

    public int maxHP;
    public int currentHP;
    public int coin;
    public int soul;

    private bool settingUIIsActive = false;

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

    public void activateSettingUI()
    {
        if(!settingUIIsActive)
        {
            settingUIIsActive = true;
            settingUI.gameObject.SetActive(settingUIIsActive);
        }
        else
        {
            settingUI.gameObject.SetActive(!settingUIIsActive);
            settingUIIsActive = false;
        }
        
    }
}