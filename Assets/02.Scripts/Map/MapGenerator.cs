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

    public void Generate()
    {
        tilemap.ClearAllTiles();

        for(int i = 0; i < mapData.Count; i++)
        {
            for(int j = 0; j <  mapData[i].Count; j++)
            {

            }
        }
    }
}