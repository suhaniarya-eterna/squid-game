using UnityEngine;

public class GlassTile : MonoBehaviour
{
    public bool isSafe = true;      // set in inspector
    public float breakDelay = 0.7f; // delay before breaking

    bool stepped = false;

     private void OnCollisionEnter(Collision collision)
    {
        if (stepped) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            stepped = true;
            Debug.Log("Player stepped on glass tile. Safe: " + isSafe);
            if (!isSafe)
            {
                Invoke("BreakGlass", breakDelay);
            }
        }
    }

    void BreakGlass()
    {
        // Disable collider so player falls
        GetComponent<Collider>().enabled = false;

        // Optional: hide glass
        GetComponent<MeshRenderer>().enabled = false;

        Debug.Log("Glass shattered!");
    }
}