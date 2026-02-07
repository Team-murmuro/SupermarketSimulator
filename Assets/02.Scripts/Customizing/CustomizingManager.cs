using UnityEngine;
using Utils.ClassUtility;
using System.Collections.Generic;

public class CustomizingManager : MonoBehaviour
{
    private static CustomizingManager instance;
    public static CustomizingManager Instance {  get { return instance; } }

    [Header("Sprites")]
    public List<CustomizingSprites> back;
    public List<CustomizingSprites> front;
    public List<CustomizingSprites> left;

    [Header("AnimationSet")] // 파츠별 저장 리스트
    public List<PartsSets> animationSet;

    private string[] motionName = new string[] { "Idle_", "Walk_", "Run_" };
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

    public void OnCustomizing(AnimatorOverrideController _aoc, int[] _customizingSpriteIndex, int _motion, int _dir, int _parts, int _type)
    {
        _customizingSpriteIndex[_parts] = _type;

        _aoc[motionName[_motion] + dirName[_dir] + aocName[_parts]] = 
            animationSet[_customizingSpriteIndex[_parts]].partsSets[_parts].sets[_dir].motionSets[_motion];
    }

    public void OnRandomCustomizing(AnimatorOverrideController _aoc, int[] _customizingSpriteIndex)
    {
        for (int i = 0; i < _customizingSpriteIndex.Length; i++)
        {
            _customizingSpriteIndex[i] = Random.Range(0, 2);
        }

        // 모션
        for (int i = 0; i < 2; i++)
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