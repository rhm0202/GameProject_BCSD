using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas settingUI;
    [SerializeField]
    public GameObject pauseMenuUI;
    [SerializeField]
    public GameObject settingMenuUI;

    public void OnClickResume()
    {
        pauseMenuUI.SetActive(false);
        settingUI.gameObject.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void OnClickSetting()
    {
        pauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(true);
    }

    public void OnClickSettingClose ()
    {
        settingMenuUI.SetActive(false);
        settingUI.gameObject.SetActive(false);
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
