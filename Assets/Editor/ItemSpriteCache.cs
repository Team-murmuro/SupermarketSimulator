using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public static class ItemSpriteCache
{
    private static Dictionary<string, Sprite> spriteMap;

    public static Dictionary<string, Sprite> Build()
    {
        if (spriteMap != null)
            return spriteMap;

        spriteMap = new Dictionary<string, Sprite>();

        // 특정 폴더의 모든 Sprite 검색
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { "Assets/04.Images/Items" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);

            spriteMap[sprite.name] = sprite;
        }

        return spriteMap;
    }
}