using System.IO;
using UnityEditor;
using UnityEngine;
using Utils.ClassUtility;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

// TileMap Data 자동 생성기
public class TileDataGenerator
{
    private const string dataPath = "Assets/Resources/CSV/TileMapData.csv";

    [MenuItem("Tools/GenerateTileData")]
    static void Generate()
    {
        if (!File.Exists(dataPath))
            return;

        string[] lines = File.ReadAllLines(dataPath);
        List<TileDatabase> datas = new List<TileDatabase>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');

            string fileName = row[0];
            int tileID = int.Parse(row[1]);
            int layer = int.Parse(row[2]);

            TileBase tile = FindTile(fileName);

            if (tile == null)
            {
                Debug.LogWarning("Tile not found : " + fileName);
                continue;
            }

            TileDatabase data = new TileDatabase();
            data.tileID = tileID;
            data.tile = tile;
            data.layer = (Utils.EnumType.TileMapLayer)layer;

            datas.Add(data);
        }

        MapGenerator generator = Object.FindFirstObjectByType<MapGenerator>();
        generator.tileDatas = datas.ToArray();
        EditorUtility.SetDirty(generator);
    }

    static TileBase FindTile(string name)
    {
        string[] guids = AssetDatabase.FindAssets("t:Tile", new[] { "Assets/09.TileMap/TestTiles" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            TileBase tile = AssetDatabase.LoadAssetAtPath<TileBase>(path);

            if (tile.name == name)
                return tile;
        }

        return null;
    }
}