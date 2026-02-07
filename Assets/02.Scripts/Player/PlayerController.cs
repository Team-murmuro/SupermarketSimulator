using UnityEngine;
using Utils.EnumType;
using Utils.ClassUtility;

public class PlayerController : MonoBehaviour
{
    private PlayerState playerState = PlayerState.Idle;
    private PlayerData playerData;

    private AnimatorOverrideController playerAOC;
    private Animator playerAnimator;
    private SpriteRenderer[] playerSR;
    private Rigidbody2D playerRb;

    private Vector2 moveDir;
    private Vector2 lookDir = Vector2.down;
    private Direction currentDir;
    private const float moveThreshold = 0.01f;

    private int[] customizingSpriteIndex = new int[6] { 1, 1, 1, 1, 1, 1 };

    private bool isMove = false;
    private bool isRun = false;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerAOC = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        playerAnimator.runtimeAnimatorController = playerAOC;

        playerSR = GetComponentsInChildren<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerData = DataManager.Instance.LoadJson<PlayerList>(DataManager.Instance.playerDataFileName).Players[0];
    }

    private void Update()
    {
        Move();
        Run();
    }

    // 이동
    public void Move()
    {
        if (isRun)
            return;

        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.linearVelocity = moveDir.normalized * playerData.moveSpeed;
        isMove = moveDir.sqrMagnitude > moveThreshold;

        if (moveDir.sqrMagnitude > moveThreshold)
            lookDir = Quantize4Dir(moveDir);

        playerAnimator.SetBool("isMove", isMove);
        playerAnimator.SetFloat("xDir", lookDir.x);
        playerAnimator.SetFloat("yDir", lookDir.y);

        if (moveDir.y > 0)
            SetDirection(Direction.Back);
        else if (moveDir.y < 0)
            SetDirection(Direction.Front);
        else if (moveDir.x != 0)
            SetDirection(moveDir.x > 0 ? Direction.Right : Direction.Left);
    }

    // 달리기
    public void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerRb.linearVelocity = moveDir.normalized * playerData.runSpeed;
            isMove = false;
            isRun = true;

            if (moveDir.sqrMagnitude > moveThreshold)
                lookDir = Quantize4Dir(moveDir);

            playerAnimator.SetBool("isRun", isRun);
            playerAnimator.SetFloat("xDir", lookDir.x);
            playerAnimator.SetFloat("yDir", lookDir.y);

            if (moveDir.y > 0)
                SetDirection(Direction.Back);
            else if (moveDir.y < 0)
                SetDirection(Direction.Front);
            else if (moveDir.x != 0)
                SetDirection(moveDir.x > 0 ? Direction.Right : Direction.Left);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRun = false;
            playerAnimator.SetBool("isRun", isRun);
        }
    }

    // 방향 변경
    public void SetDirection(Direction _dir)
    {
        if (currentDir == _dir)
            return;

        currentDir = _dir;
        playerSR[0].transform.localScale = (_dir == Direction.Left) ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

        if (_dir == Direction.Back)
            playerSR[2].sortingOrder = 6;
        else
            playerSR[2].sortingOrder = 2;
    }

    // 사선 입력 시 상/하 우선 처리
    public Vector2 Quantize4Dir(Vector2 input)
    {
        if (Mathf.Abs(input.y) >= Mathf.Abs(input.x))
            return new Vector2(0, Mathf.Sign(input.y));
        else
            return new Vector2(Mathf.Sign(input.x), 0);
    }

    // 수동 캐릭터 디자인 생성
    public void OnCustomizing(int _motion, int _dir, int _parts, int _type)
    {
        CustomizingManager.Instance.OnCustomizing(playerAOC, customizingSpriteIndex, _motion, _dir, _parts, _type);
    }

    // 랜덤한 디자인의 캐릭터 생성
    public void OnCustomizing()
    {
        CustomizingManager.Instance.OnRandomCustomizing(playerAOC, customizingSpriteIndex);
    }
}