using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int soul = 0;
    public int Soul     // �ܺο��� �ҿ��� ������ �� ������ּ���.
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
            // ���⿡ �ҿ��� ����� ������ ȣ���� �޼��带 �߰��� �� �ֽ��ϴ�.
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
