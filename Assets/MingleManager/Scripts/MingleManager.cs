using UnityEngine;

public class MingleManager : MonoBehaviour
{
    public int targetRoom;
    public float musicTime = 8f;

    public bool isMusicPlaying = true;

    void Start()
    {
        StartRound();
    }

    void StartRound()
    {
        isMusicPlaying = true;
        Debug.Log("🎵 Music playing... move!");

        Invoke("StopMusic", musicTime);
    }

    void StopMusic()
    {
        isMusicPlaying = false;

        targetRoom = Random.Range(1, 5); // rooms 1–4
        Debug.Log("🚨 Go to Room: " + targetRoom);

        Invoke("CheckPlayers", 3f); // give time to enter rooms
    }

    void CheckPlayers()
    {
        PlayerTracker[] players = FindObjectsOfType<PlayerTracker>();

        foreach (PlayerTracker player in players)
        {
            if (player.currentRoom != targetRoom)
            {
                Debug.Log("💀 Player eliminated (wrong room)");
                player.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("✅ Player survived");
            }
        }

        Invoke("StartRound", 3f); // next round
    }
}