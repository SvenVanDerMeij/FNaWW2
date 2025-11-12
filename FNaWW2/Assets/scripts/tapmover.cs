using UnityEngine;

public class TapMover : MonoBehaviour
{
    [Header("Movement Area")]
    public Vector2 minPosition = new Vector2(-5f, -3f);
    public Vector2 maxPosition = new Vector2(5f, 3f);

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Move to a random position within the given range
        MoveToRandomPosition();

        // Also add score (if you have the ScoreManager)
        ScoreManager.Instance.AddScore(1);
    }

    void MoveToRandomPosition()
    {
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomY = Random.Range(minPosition.y, maxPosition.y);

        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }
}
