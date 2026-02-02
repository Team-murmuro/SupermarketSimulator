using System;
using UnityEngine;
using System.Collections.Generic;

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
        public int moveSpeed;
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
        public AnimationSet[] partsSets;
    }

    [Serializable]
    public class MotionSets
    {
        // Idel, Walk 저장 배열
        public AnimationClip[] motionSets;
    }
}