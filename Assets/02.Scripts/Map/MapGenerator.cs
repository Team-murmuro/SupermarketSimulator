using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    private List<Dictionary<string, object>> mapData;

    private Tilemap tilemap;
    public TileBase[] tileBases;

    private void Awake()
    {
        mapData = CSVReader.Read("CSV/MapData");
        tilemap = transform.GetChild(0).GetComponent<Tilemap>();
    }

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        tilemap.ClearAllTiles();

        for(int y = 0; y < mapData.Count; y++)
        {
            for(int x = 0; x <  mapData[y].Count; x++)
            {
                Vector3Int pos = new Vector3Int(x, -y, 0);
                string value = mapData[y][x.ToString()].ToString().Trim();

                if (int.TryParse(value, out int tileIndex))
                    tilemap.SetTile(pos, tileBases[tileIndex]);
            }
        }
    }
}