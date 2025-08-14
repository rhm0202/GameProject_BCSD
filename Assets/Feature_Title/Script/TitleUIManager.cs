using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject settingMenuUI;

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("stage1");
    }
    public void OnClickLoadGame()
    {
        Debug.Log("진행중인 게임을 불러옵니다.");
    }

    public void OnClickSetting()
    {
        settingMenuUI.SetActive(true);
    }

    public void OnClickSettingClose ()
    {
        settingMenuUI.SetActive(false);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
