using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
    public string firstSceneName;
    public bool isStart = false;
    void Awake()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(firstSceneName, LoadSceneMode.Additive);
    }
}
