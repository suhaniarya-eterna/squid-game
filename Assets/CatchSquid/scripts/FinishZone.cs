using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public CatchSquidManager manager;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            manager.PlayerReachedGoal();
        }
    }
}