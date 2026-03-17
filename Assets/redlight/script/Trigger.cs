using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger!");
            // You can add additional logic here, such as activating a door, starting a cutscene, etc.
        }
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
