using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SoulPoolManager : MonoBehaviour
{
    public static SoulPoolManager instance;

    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;
    [SerializeField] private Soul soulPool;
    [SerializeField] private GameObject soulPrefab;

    public IObjectPool<Soul> ObjectPool { get; set; }

    public static SoulPoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<SoulPoolManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("PoolManager");
                    instance = obj.AddComponent<SoulPoolManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        ObjectPool = new ObjectPool<Soul>(CreateSoul, OnTakeFromPool, OnReturnedToPool, OnDestroyPool, true, defaultCapacity, maxSize);
        Soul obj = null;

        for (int i = 0; i < defaultCapacity; i++)
        {
            obj = CreateSoul();
            obj.gameObject.SetActive(false);
        }
    }

    private Soul CreateSoul()
    {
        GameObject soulInstance = Instantiate(soulPrefab);
        Soul soul = soulInstance.GetComponent<Soul>();
        soul.Pool = ObjectPool;
        return soul;
    }

    private void OnTakeFromPool(Soul soul)
    {
        soul.gameObject.SetActive(true);
        Debug.Log("Soul Taken From Pool");
        soul.Init();
    }

    private void OnReturnedToPool(Soul soul)
    {
        soul.gameObject.SetActive(false);
        Debug.Log("Soul Returned To Pool");
    }

    private void OnDestroyPool(Soul soul)
    {
        Destroy(soul.gameObject);
    }
}
