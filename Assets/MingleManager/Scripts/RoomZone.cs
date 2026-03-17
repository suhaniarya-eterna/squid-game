using UnityEngine;

public class RoomZone : MonoBehaviour
{
    public int roomNumber;

    void OnTriggerEnter(Collider other)
    {
        PlayerTracker player = other.GetComponent<PlayerTracker>();

        if (player != null)
        {
            player.currentRoom = roomNumber;
            Debug.Log("Player entered room: " + roomNumber);
        }
    }
}