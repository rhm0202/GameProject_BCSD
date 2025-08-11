using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{

    public GameObject player;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            SceneManager.LoadScene("Stage1-2");
        }
    }

}
