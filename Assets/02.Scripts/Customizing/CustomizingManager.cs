using UnityEngine;
using Utils.EnumType;
using Utils.ClassUtility;
using System.Collections.Generic;

public class CustomizingManager : MonoBehaviour
{
    private static CustomizingManager instance;
    public static CustomizingManager Instance {  get { return instance; } }

    [Header("Sprites")]
    public List<CustomizingSprites> front;
    public List<CustomizingSprites> back;
    public List<CustomizingSprites> left;

    [Header("AnimationSet")] // 타입별로 저장 리스트
    public List<PartsSets> animationSet;

    private string[] motionName = new string[] { "Idle_", "Walk_" };
    private string[] dirName = new string[] { "Back_", "Front_", "Left_" };
    private string[] aocName = new string[] { "Body", "Face", "Hair", "Top", "Bottoms", "Shoes" };

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
    }

    #region 방향 변경 시 Sprite 변경
    //public void ChangeDirection(SpriteRenderer[] _spriteRenderer, int[] _customizingSpriteIndex, Direction _dir)
    //{
    //    if(_dir == Direction.Front)
    //    {
    //        for (int i = 0; i < _spriteRenderer.Length; i++)
    //            _spriteRenderer[i].sprite = front[i].sprites[_customizingSpriteIndex[i]];
    //    }
    //    else if(_dir == Direction.Back)
    //    {
    //        for (int i = 0; i < _spriteRenderer.Length; i++)
    //        {
    //            if (i == 1)
    //                continue;
    //            _spriteRenderer[i].sprite = back[i].sprites[_customizingSpriteIndex[i]];
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < _spriteRenderer.Length; i++)
    //            _spriteRenderer[i].sprite = left[i].sprites[_customizingSpriteIndex[i]];
    //    }
    //}
    #endregion

    public void ChangeAnimationClip(AnimatorOverrideController _aoc, int[] _customizingSpriteIndex)
    {
        // 모션
        for(int i = 0; i < 2; i++)
        {
            // 방향
            for(int j = 0; j < dirName.Length; j++)
            {
                // 파츠
                for(int k = 0; k < aocName.Length; k++)
                {
                    if (j == 0 && k == 1)
                        continue;

                    _aoc[motionName[i] + dirName[j] + aocName[k]] =
                        animationSet[_customizingSpriteIndex[k]].partsSets[k].sets[j].motionSets[i];
                }
            }
        }
    }
}