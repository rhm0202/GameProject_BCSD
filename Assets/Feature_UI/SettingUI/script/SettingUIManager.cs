using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas settingUICanvas;
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject settingMenuUI;
    [SerializeField]
    private PlayerUIManager playerUI;

    public void OnClickResume()
    {
        playerUI.settingUIIsActive = false;
        pauseMenuUI.SetActive(false);
        settingUICanvas.gameObject.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void OnClickSetting()
    {
        pauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(true);
    }

    public void OnClickSettingClose ()
    {
        playerUI.settingUIIsActive = false;
        settingMenuUI.SetActive(false);
        settingUICanvas.gameObject.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void OnClickToTitle()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Title");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
