using System;
using UnityEngine;
using Utils.EnumType;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace Utils.ClassUtility
{
    // 플레이어 데이터 구조
    [Serializable]
    public class PlayerList
    {
        public List<PlayerData> Players;
    }

    [Serializable]
    public class PlayerData
    {
        public int id;
        public int level;
        public string name;
        public string gender;
        public float moveSpeed;
        public float runSpeed;
    }

    // 아이템 데이터 구조
    [Serializable]
    public class ItemList
    {
        public List<ItemData> Items;
    }

    [Serializable]
    public class ItemData
    {
        public int id;
        public string iconKey;
        public string itemEName;
        public string itemKName;
        public float price;
        public int packageQuantity;
        public ItemCategoryType categoryType;
        public ItemCategory category;
    }

    // 커스터마이징 파츠별 Sprite 저장 배열
    [Serializable]
    public class CustomizingSprites
    {
        public Sprite[] sprites;
    }

    [Serializable]
    public class PartsSets
    {
        // Body, Face, Hair, Top, Bottoms, Shoes 저장 배열
        public AnimationSetSO[] partsSets;
    }

    [Serializable]
    public class MotionSets
    {
        // Idel, Walk 저장 배열
        public AnimationClip[] motionSets;
    }

    // TileData 구조
    [Serializable]
    public class TileDatabase
    {
        public int tileID;
        public TileBase tile;
        public TileMapLayer layer;    // 바닥, 벽 등 타일맵 레이어 구분
    }
}