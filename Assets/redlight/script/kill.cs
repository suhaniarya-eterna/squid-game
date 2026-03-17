using UnityEngine;

public class kill : MonoBehaviour
{
    public enum LightState
    {
        Green,
        Yellow,
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
                SetState(LightState.Yellow);
            }
            else if (currentState == LightState.Yellow)
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

            // 25% chance of fake green trap
            if (Random.value < 0.25f)
            {
                Invoke("FakeGreenTrap", 0.3f);
            }
        }
        else if (newState == LightState.Yellow)
        {
            timer = Random.Range(0.5f, 1f);
            Debug.Log("YELLOW - DON'T MOVE (trap)");
        }
        else if (newState == LightState.Red)
        {
            timer = Random.Range(2f, 5f);
            Debug.Log("RED - Don't Move!");
        }
    }

    void FakeGreenTrap()
    {
        if (currentState == LightState.Green)
        {
            SetState(LightState.Yellow);
        }
    }
}