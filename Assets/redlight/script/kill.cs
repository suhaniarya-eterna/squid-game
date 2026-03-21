using UnityEngine;

public class kill : MonoBehaviour
{
    public enum LightState
    {
        Green,
        Red
    }

    public LightState currentState;

    float timer;

    void Start()
    {
        SetState(LightState.Green);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (currentState == LightState.Green)
            {
                SetState(LightState.Red);
            }
            else
            {
                SetState(LightState.Green);
            }
        }
    }

    void SetState(LightState newState)
    {
        currentState = newState;

        if (newState == LightState.Green)
        {
            timer = Random.Range(3f, 6f);
            Debug.Log("GREEN - Move!");
        }
        else if (newState == LightState.Red)
        {
            timer = Random.Range(1f, 4f); 
            Debug.Log("RED - Don't Move!");
        }
    }
}