using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<Dictionary<string, object>> data;

    private void Start()
    {
        data = CSVReader.Read("CSV/MapData");
        Debug.Log(data[0]["1"]);
    }
}