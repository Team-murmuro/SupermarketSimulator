using UnityEngine;

[CreateAssetMenu(fileName = "SpritesSetSO", menuName = "Character/SpritesSetSO")]
public class SpritesSetSO : ScriptableObject
{
    public Sprite idleBack;
    public Sprite idleFront;
    public Sprite idleLeft;

    public Sprite walkBack;
    public Sprite walkFront;
    public Sprite walkLeft;
}