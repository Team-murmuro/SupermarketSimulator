using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private PlayerController playerController;
    private Canvas mainCanvas;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Init();
        instance = this;
    }

    private void Init()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
    }
}