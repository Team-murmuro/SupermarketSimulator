using System;
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
}