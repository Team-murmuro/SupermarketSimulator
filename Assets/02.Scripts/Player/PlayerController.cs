using UnityEngine;
using Utils.EnumType;

public class PlayerController : MonoBehaviour
{
    private PlayerState playerState;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void Move()
    {
        
    }
}