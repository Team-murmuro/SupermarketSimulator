using UnityEngine;
using Utils.EnumType;
using Utils.ClassUtility;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AnimationSetSO", menuName = "Character/AnimationSetSO")]
public class AnimationSetSO : ScriptableObject
{
    public CustomizingParts parts;
    // Back, Front, Left 저장 배열
    public List<MotionSets> sets;
}