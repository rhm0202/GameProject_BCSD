using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUIManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 

    public void OnClickResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
    }

    public void OnClickSetting()
    {
        Debug.Log("설정창 열기 (직접 구현 필요)");
        // 예: settingUI.SetActive(true);
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
