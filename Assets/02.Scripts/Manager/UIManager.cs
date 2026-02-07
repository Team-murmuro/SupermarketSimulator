using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Utils.EnumType;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private PlayerController playerController;

    private Canvas mainCanvas;
    private Image[] partsImages;
    private GameObject[] partsObjects;

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
        playerController = GameObject.Find("Character").GetComponent<PlayerController>();

        mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        partsImages = mainCanvas.transform.GetChild(1).GetChild(0).GetComponentsInChildren<Image>().Skip(1).ToArray();
        partsObjects = mainCanvas.transform.GetChild(1).GetChild(1).Cast<Transform>().Select(t => t.gameObject).ToArray();
    }
}