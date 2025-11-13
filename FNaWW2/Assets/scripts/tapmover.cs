using UnityEngine;

public class TapMover : MonoBehaviour
{
    [Header("Padding")]
    [Tooltip("Distance from screen edges (prevents half-visible cube)")]
    public float padding = 0.5f;

    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        mainCamera = Camera.main;
        
        // Get the size of the cube/object using its renderer bounds
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            objectWidth = renderer.bounds.extents.x;
            objectHeight = renderer.bounds.extents.y;
        }
        else
        {
            // Fallback if no renderer
            objectWidth = 0.5f;
            objectHeight = 0.5f;
        }
    }

    void OnMouseDown()
    {
        MoveToRandomPosition();
        ScoreManager.Instance.AddScore(1);
    }

    void MoveToRandomPosition()
    {
        if (mainCamera == null) return;

        // Calculate the distance from camera to the object's current Z plane
        float distanceFromCamera = Mathf.Abs(transform.position.x - mainCamera.transform.position.x);

        // Get screen bounds in world space at the object's distance from camera
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceFromCamera));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distanceFromCamera));

        // Calculate bounds with padding
        float minY = bottomLeft.y + objectHeight + padding;
        float maxY = topRight.y - objectHeight - padding;
        float minZ = bottomLeft.z + objectWidth + padding;
        float maxZ = topRight.z - objectWidth - padding;

        // Generate random position (keep X the same since camera looks along X axis)
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        transform.position = new Vector3(transform.position.x, randomY, randomZ);

        // Debug info
        Debug.Log($"Camera bounds - Y: [{minY:F2}, {maxY:F2}], Z: [{minZ:F2}, {maxZ:F2}]");
        Debug.Log($"New position: X:{transform.position.x:F2}, Y:{randomY:F2}, Z:{randomZ:F2}");
    }
}