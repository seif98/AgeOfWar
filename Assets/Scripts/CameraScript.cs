using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public float edgeSize = 20f;
    public RectTransform backgroundRect;

    private Camera cam;
    public float minX = 0;
    public float maxX = 32f;

    private void Start()
    {
        cam = Camera.main;
        UpdateBounds();
    }

    private void UpdateBounds()
    {
         float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        Vector3[] corners = new Vector3[4];
        backgroundRect.GetWorldCorners(corners);

        float bgLeft = corners[0].x;
        float bgRight = corners[3].x;

        minX = bgLeft + halfWidth;
        maxX = bgRight - halfWidth;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        float screenWidth = Screen.width;
        // Move left
        if (Input.mousePosition.x < edgeSize)
        {
            pos.x -= scrollSpeed * Time.deltaTime;
        }

        // Move right
        if (Input.mousePosition.x > screenWidth - edgeSize)
            pos.x += scrollSpeed * Time.deltaTime;

        // Clamp to level bounds
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
    
}
