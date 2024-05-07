using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    [SerializeField] private int targetFrameRate;

    private void Awake()
    {
        if (targetFrameRate <= 0)
        {
            targetFrameRate = 30;
        }

        Application.targetFrameRate = targetFrameRate;
    }
}
