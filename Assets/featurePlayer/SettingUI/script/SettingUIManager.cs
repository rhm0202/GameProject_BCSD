using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUIManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 

    public void OnClickResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
    }

    public void OnClickSetting()
    {
        Debug.Log("����â ���� (���� ���� �ʿ�)");
        // ��: settingUI.SetActive(true);
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
