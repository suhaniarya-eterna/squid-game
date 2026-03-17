using UnityEngine;

public class detectplayermovement : MonoBehaviour
{
    public kill gameController;

    Vector3 lastPosition;
    float movementThreshold = 0.01f;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        float movement = Vector3.Distance(transform.position, lastPosition);

        if (movement > movementThreshold)
        {
            if (gameController.currentState != kill.LightState.Green)
            {
                Die();
            }
        }

        lastPosition = transform.position;
    }

    void Die()
    {
        Debug.Log("Player Eliminated!");
        Destroy(gameObject);
    }
}