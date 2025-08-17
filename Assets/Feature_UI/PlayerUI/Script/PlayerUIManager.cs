using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트 사용
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;

    [SerializeField]
    private Slider hpBar; // Inspector에서 연결할 HP 바
    [SerializeField]
    private TMP_Text hpText;
    [SerializeField]
    private Canvas settingUI;
    [SerializeField]
    public GameObject pauseMenuUI;

    public int maxHP;
    public int currentHP;
    public int coin;
    public int soul;

    public bool settingUIIsActive = false;

    #region Singleton Pattern
    public static PlayerUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<PlayerUIManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("PlayerUIManager");
                    instance = obj.AddComponent<PlayerUIManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

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
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(settingUIIsActive);
            settingUI.gameObject.SetActive(settingUIIsActive);
        }
        else
        {
            settingUIIsActive = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(settingUIIsActive);
            settingUI.gameObject.SetActive(settingUIIsActive);      
        }
        
    }
}