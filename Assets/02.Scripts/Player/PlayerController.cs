using UnityEngine;
using UnityEngine.UIElements;
using Utils.ClassUtility;
using Utils.EnumType;

public class PlayerController : MonoBehaviour
{
    private PlayerData playerData;
    private Rigidbody2D playerRb;
    private SpriteRenderer[] playerSR;
    private PlayerState playerState = PlayerState.Idle;

    private Vector2 moveDir;
    private Direction currentDir;
    private const float moveThreshold = 0.01f;

    private int[] customizingSpriteIndex = new int[6] { 1, 1, 1, 1, 1, 1 };

    private bool isMove = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSR = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        playerData = DataManager.Instance.LoadJson<PlayerList>(DataManager.Instance.playerDataFileName).Players[0];
    }

    private void Update()
    {
        Move();
    }

    // 이동
    public void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.linearVelocity = moveDir * playerData.moveSpeed;
        isMove = moveDir.sqrMagnitude > moveThreshold;

        if (moveDir.y > 0)
            SetDirection(Direction.Back);
        else if (moveDir.y < 0)
            SetDirection(Direction.Front);
        else if (moveDir.x != 0)
            SetDirection(moveDir.x > 0 ? Direction.Right : Direction.Left);
    }

    // 방향 변경
    public void SetDirection(Direction _dir)
    {
        if (currentDir == _dir)
            return;

        currentDir = _dir;
        CustomizingManager.Instance.ChangeDirection(playerSR, customizingSpriteIndex, currentDir);
    }
}