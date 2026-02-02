using UnityEngine;
using Utils.ClassUtility;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AnimationSet", menuName = "Character/AnimationSet")]
public class AnimationSet : ScriptableObject
{
    // Back, Front, Left 저장 배열
    public List<MotionSets> sets;
}