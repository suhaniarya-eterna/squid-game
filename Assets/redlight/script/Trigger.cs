using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger!");
        }
    }
    
    
    void Start()
    {
        
    }

      void Update()
    {
        
    }
}
