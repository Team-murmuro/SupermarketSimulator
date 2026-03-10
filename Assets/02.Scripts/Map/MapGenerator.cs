using System.Linq;
using UnityEngine;
using Utils.EnumType;
using Utils.ClassUtility;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public TileDatabase[] tileDatas;
    private Dictionary<int, TileDatabase> tileDict;
    private List<Dictionary<string, object>> mapData;

    private Tilemap wallTilemap;
    private Tilemap groundTilemap;

    private void Awake()
    {
        mapData = CSVReader.Read("CSV/MapData");
        wallTilemap = transform.GetChild(0).GetComponent<Tilemap>();
        groundTilemap = transform.GetChild(1).GetComponent<Tilemap>();

        tileDict = new Dictionary<int, TileDatabase>();

        foreach (var data in tileDatas)
        {
            tileDict[data.tileID] = data;
        }
    }

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        wallTilemap.ClearAllTiles();
        groundTilemap.ClearAllTiles();

        for (int y = 0; y < mapData.Count; y++)
        {
            for(int x = 0; x <  mapData[y].Count; x++)
            {
                Vector3Int pos = new Vector3Int(x, -y, 0);
                string value = mapData[y][x.ToString()].ToString().Trim();

                if (int.TryParse(value, out int tileID))
                {
                    if (tileDict.TryGetValue(tileID, out TileDatabase tileData))
                    {
                        if (tileData.layer == TileMapLayer.Ground)
                            groundTilemap.SetTile(pos, tileData.tile);
                        else if (tileData.layer == TileMapLayer.Wall)
                            wallTilemap.SetTile(pos, tileData.tile);
                    }
                }
            }
        }

        CameraCenterToMap();
    }

    public void CameraCenterToMap()
    {
        Bounds bounds = wallTilemap.localBounds;
        Vector3 center = bounds.center;

        Camera.main.transform.position = new Vector3(center.x, center.y, Camera.main.transform.position.z);
    }
}