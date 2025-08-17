using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject miniMap;
    [SerializeField]
    private GameObject largeMap;

    public bool IsLargeMapOpen { get; private set; }

    private void Awake()
    {
   
        CloseLargeMap();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (!IsLargeMapOpen)
            {
                OpenLargeMap();
            }
            else
            {
                CloseLargeMap();
            }
        }
    }

    private void OpenLargeMap()
    {
        miniMap.SetActive(false);
        largeMap.SetActive(true);
        IsLargeMapOpen = true;
    }
    private void CloseLargeMap()
    {
        miniMap.SetActive(true );
        largeMap.SetActive(false);
        IsLargeMapOpen = false;
    }
}
