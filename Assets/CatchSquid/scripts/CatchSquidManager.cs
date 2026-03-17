using UnityEngine;

public class CatchSquidManager : MonoBehaviour
{
    public Transform finishZone;

    public void PlayerReachedGoal()
    {
        Debug.Log("🏆 Player survived Catch Squid!");
    }

    public void PlayerCaught(GameObject player)
    {
        Debug.Log("💀 Player caught!");
        player.SetActive(false);
    }
}