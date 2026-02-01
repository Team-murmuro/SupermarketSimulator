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

    public List<AnimationSet> set;

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
    public void ChangeDirection(SpriteRenderer[] _spriteRenderer, int[] _customizingSpriteIndex, Direction _dir)
    {
        if(_dir == Direction.Front)
        {
            for (int i = 0; i < _spriteRenderer.Length; i++)
                _spriteRenderer[i].sprite = front[i].sprites[_customizingSpriteIndex[i]];
        }
        else if(_dir == Direction.Back)
        {
            for (int i = 0; i < _spriteRenderer.Length; i++)
            {
                if (i == 1)
                    continue;
                _spriteRenderer[i].sprite = back[i].sprites[_customizingSpriteIndex[i]];
            }
        }
        else
        {
            for (int i = 0; i < _spriteRenderer.Length; i++)
                _spriteRenderer[i].sprite = left[i].sprites[_customizingSpriteIndex[i]];
        }
    }
    #endregion

    // 랜덤한 디자인의 캐릭터 생성
    public void RandomCustomizing(SpriteRenderer[] _spriteRenderer, int[] _customizingSpriteIndex)
    {
        for(int i = 0; i < _customizingSpriteIndex.Length; i++)
        {
            _customizingSpriteIndex[i] = Random.Range(0, front[i].sprites.Length);
            _spriteRenderer[i].sprite = front[i].sprites[_customizingSpriteIndex[i]];
        }
    }
}