using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int soul = 0;
    public int Soul     // 외부에서 소울을 참조할 때 사용해주세요.
    {
        get { return soul; }
        set
        {
            if(value < 0)
            {
                Debug.LogWarning("Soul cannot be negative.");
                return;
            }
            soul = value;
            Debug.Log("Soul changed: " + soul);
            // 여기에 소울이 변경될 때마다 호출할 메서드를 추가할 수 있습니다.
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
