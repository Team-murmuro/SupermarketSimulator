using UnityEngine;

[CreateAssetMenu(fileName = "AnimationSet", menuName = "Character/AnimationSet")]
public class AnimationSet : ScriptableObject
{
    public AnimationClip idleBack;
    public AnimationClip idleFront;
    public AnimationClip idleLeft;

    public AnimationClip walkBack;
    public AnimationClip walkFront;
    public AnimationClip walkLeft;
}
