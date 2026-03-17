using UnityEngine;

public class RopeRotation : MonoBehaviour
{
    public float speed = 120f;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}