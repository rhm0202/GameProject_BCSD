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
    private Canvas checkPointUICanvas;
    [SerializeField]
    private GameObject checkPointMenuUI;
    [SerializeField]
    private GameObject mainMenuUI;
    [SerializeField]
    private GameObject soulMenuUI;

    //SettingUI에서 사용
    public void OnClickResume()
    {
        PlayerUIManager.instance.settingUIIsActive = false;
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
        settingMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OnClickToCheckPoint()
    {
        Debug.Log("체크 포인트로 이동합니다.");
    }

    public void OnClickToTitle()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Title");
    }

    public void OnClickExitGame()
    {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }

    //소울 창 관련
    public void OpenCheckPointUI() 
    {
        Time.timeScale = 0f;
        checkPointUICanvas.gameObject.SetActive(true);
       checkPointMenuUI.SetActive(true);
        mainMenuUI.SetActive(true);
    }
    public void CloseCheckPointUI()
    {
        Time.timeScale = 1f;
        mainMenuUI.SetActive(false);
        checkPointMenuUI.SetActive(false);
        checkPointUICanvas.gameObject.SetActive(false);
    }
}
