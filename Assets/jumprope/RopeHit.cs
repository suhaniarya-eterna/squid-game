using UnityEngine;

public class RopeHit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("💀 Player hit by rope!");
        }
    }
}