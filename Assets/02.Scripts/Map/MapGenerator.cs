using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    private List<Dictionary<string, object>> mapData;

    private Tilemap wallTilemap;
    private Tilemap groundTilemap;
    public TileBase[] tileBases;

    private int[] wallIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    private int[] groundIndex = new int[] { 13 };

    private void Awake()
    {
        mapData = CSVReader.Read("CSV/MapData");
        wallTilemap = transform.GetChild(0).GetComponent<Tilemap>();
        groundTilemap = transform.GetChild(1).GetComponent<Tilemap>();
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

                if (int.TryParse(value, out int tileIndex))
                {
                    if (wallIndex.Contains(tileIndex))
                        wallTilemap.SetTile(pos, tileBases[tileIndex]);
                    else if (groundIndex.Contains(tileIndex))
                        groundTilemap.SetTile(pos, tileBases[tileIndex]);
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