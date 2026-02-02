using UnityEngine;

[CreateAssetMenu(fileName = "SpritesSet", menuName = "Character/SpritesSet")]
public class SpritesSet : ScriptableObject
{
    public Sprite idleBack;
    public Sprite idleFront;
    public Sprite idleLeft;

    public Sprite walkBack;
    public Sprite walkFront;
    public Sprite walkLeft;
}