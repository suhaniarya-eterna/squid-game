using UnityEngine;

public class SeekerCatch : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("💀 Player caught!");

            other.gameObject.SetActive(false);
        }
    }
}