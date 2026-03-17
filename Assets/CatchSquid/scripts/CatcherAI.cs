using UnityEngine;

public class CatcherAI : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
    }
}