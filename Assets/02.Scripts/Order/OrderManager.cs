using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private static OrderManager instance;
    public static OrderManager Instance { get { return instance; } }

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

    }

    // 컴퓨터 오브젝트와 상호작용
    public void OnComputerInteraction()
    {

    }

    // 물류주문 버튼 클릭
    public void OnyOrderButton()
    {

    }
}
