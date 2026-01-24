using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public void CameraCenterAndFit(Tilemap _tilemap)
    {
        Bounds bounds = _tilemap.localBounds;
        Vector3 center = bounds.center;

        Camera cam = Camera.main;
        cam.transform.position = new Vector3(center.x, center.y, cam.transform.position.z);

        float mapWidth = bounds.size.x;
        float mapHeight = bounds.size.y;

        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = mapWidth / mapHeight;

        if (screenRatio >= targetRatio)
            cam.orthographicSize = mapHeight / 2f;
        else
            cam.orthographicSize = mapWidth / 2f / screenRatio;
    }
}
