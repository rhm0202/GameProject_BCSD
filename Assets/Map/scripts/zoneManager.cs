using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zoneManager : MonoBehaviour
{
    // 로드할 씬의 이름
    public string nextZoneSceneName;
    // 언로드할 씬의 이름
    public string currentZoneSceneName;

    // 코루틴을 사용하여 비동기적으로 씬을 로드/언로드
    public void TransitionToZone(string nextZoneName, string currentZoneName)
    {
        StartCoroutine(LoadScenes(nextZoneName, currentZoneName));
    }

    private IEnumerator LoadScenes(string nextZoneName, string currentZoneName)
    {
        // 다음 씬 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextZoneName, LoadSceneMode.Additive);

        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 현재 씬 언로드 
        SceneManager.UnloadSceneAsync(currentZoneName);
    }
}