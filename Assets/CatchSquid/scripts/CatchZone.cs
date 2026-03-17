using UnityEngine;

public class CatchZone : MonoBehaviour
{
    public CatchSquidManager manager;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            manager.PlayerCaught(other.gameObject);
        }
    }
}