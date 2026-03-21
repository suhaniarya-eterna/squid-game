using UnityEngine;

public class detectplayermovement : MonoBehaviour
{
    public kill gameController;
    public bool playeractive;
    public GameObject stuff;
    public GameObject doll;
    private Animator anim;

    Vector3 lastPosition;
    float movementThreshold = 0.01f;

    void Start()
    {
        anim = doll.GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        
        if (gameObject.activeSelf == true)
        {
            playeractive = true;
        }
        if (playeractive)
        {
            stuff.SetActive(false);
        }
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