using UnityEngine;

public class Attackpatterns : MonoBehaviour
{

    public float[][] attackPatterns = new float[][]
    {
        new float[] { 0f, -0.5f, 5f, 1f}, // Pattern 1: Attack in a flat area
        new float[] { -1f, 0f, 1f, 1.5f}, // Pattern 2: Attack in front
        new float[] { 0f, 2f, 6f, 6f} // Pattern 3: Attack in big area
    };
}
