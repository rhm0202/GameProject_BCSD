using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string currnetSceneName;
    public string nextSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);

            SceneManager.UnloadSceneAsync(currnetSceneName);
           
        }
    }
    

}
