using UnityEngine;
using UnityEngine.InputSystem;

public class DalgonaCutter : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Cutting at: " + hit.point);

                if (hit.collider.CompareTag("CandyBoundary"))
                {
                    Debug.Log("💀 Candy cracked! Player eliminated.");
                }
            }
        }
    }
}