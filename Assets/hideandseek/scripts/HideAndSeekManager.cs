using UnityEngine;

public class HideAndSeekManager : MonoBehaviour
{
    public float hideTime = 10f;
    public float seekTime = 40f;

    bool seekerReleased = false;

    void Start()
    {
        Debug.Log("Round started. Hiders have 10 seconds.");
        Invoke("ReleaseSeeker", hideTime);
    }

    void ReleaseSeeker()
    {
        seekerReleased = true;
        Debug.Log("Seeker released!");
        Invoke("EndRound", seekTime);
    }

    void EndRound()
    {
        Debug.Log("⏱ Time over! Hiders win.");
    }

    public bool IsSeekerReleased()
    {
        return seekerReleased;
    }
}