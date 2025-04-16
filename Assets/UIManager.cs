using UnityEngine;
using TMPro;
using Unity.Netcode;

public class UIManager : MonoBehaviour
{
    public TMP_Text textNetState;

    private static UIManager _instance = null;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this; //this : 현재 인스턴스를 가리키는 레퍼런스
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            // 현재 인스턴스 파괴
            Destroy(gameObject);
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

    public void updateNetState()
    {
        string isServer = (NetworkManager.Singleton.IsServer)? "O" : "X";
        string isClient = (NetworkManager.Singleton.IsClient) ? "O" : "X";
        string netState = $"server : {isServer}, client : {isClient}";
        textNetState.text = netState;
    }
}
