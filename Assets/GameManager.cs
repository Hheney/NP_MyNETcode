using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance //변수 + 함수 = 필드 + 메소드 = 프로퍼티(property) → 외부 접근을 수월하게(public 선언), 외부에서는 변수처럼 사용  
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Debug.Log("GameManager has another instance");
            Destroy(gameObject);
        }
        //씬이 바뀌어도 현재 게임 오브젝트를 유지
        DontDestroyOnLoad(gameObject);
    }

    public void startHost()
    {
        if(!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Host started.");
            NetworkManager.Singleton.StartHost();
            UIManager.Instance.updateNetState();
        }
    }

    public void startServer()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Server started.");
            NetworkManager.Singleton.StartServer();
            UIManager.Instance.updateNetState();
        }
    }

    public void startClient()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            Debug.Log("Client started.");
            NetworkManager.Singleton.StartClient();
            UIManager.Instance.updateNetState();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
