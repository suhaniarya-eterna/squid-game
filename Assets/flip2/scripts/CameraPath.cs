using UnityEngine;

public class CameraPath : MonoBehaviour
{
    public Transform[] points;
    public float speed = 3f;
    private int current = 0;

    void Update()
    {
        Transform target = points[current];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            current++;
            if (current >= points.Length) current = 0;
        }
    }
}