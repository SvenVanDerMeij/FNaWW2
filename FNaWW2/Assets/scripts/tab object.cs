using UnityEngine;

public class TapObject : MonoBehaviour
{
    void OnMouseDown()
    {
        // Add 1 point when the object is clicked/tapped
        ScoreManager.Instance.AddScore(1);
    }
}
