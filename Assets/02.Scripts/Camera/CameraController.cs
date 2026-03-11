using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private float smoothTime = 0.15f;

    private Vector3 velocity = Vector2.zero;

    private void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

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