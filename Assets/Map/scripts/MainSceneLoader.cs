using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
    public string firstSceneName;

    private void Start()
    {
        SceneManager.LoadScene(firstSceneName, LoadSceneMode.Additive);
    }
}
