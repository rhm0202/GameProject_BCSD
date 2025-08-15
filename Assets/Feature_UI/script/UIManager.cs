using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas settingUICanvas;
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject settingMenuUI;

    [SerializeField]
    private PlayerUIManager playerUI;

    [SerializeField]
    private Canvas soulUICanvas;
    [SerializeField]
    private GameObject soulMenuUI;

    //SettingUI���� ���
    public void OnClickResume()
    {
        playerUI.settingUIIsActive = false;
        pauseMenuUI.SetActive(false);
        settingUICanvas.gameObject.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
    }

    public void OnClickSetting()
    {
        pauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(true);
    }

    public void OnClickSettingClose ()
    {
        settingMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OnClickToCheckPoint()
    {
        Debug.Log("üũ ����Ʈ�� �̵��մϴ�.");
    }

    public void OnClickToTitle()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Title");
    }

    public void OnClickExitGame()
    {
        Debug.Log("������ �����մϴ�.");
        Application.Quit();
    }
}
