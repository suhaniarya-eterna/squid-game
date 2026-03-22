using UnityEngine;
using TMPro;
using System.Collections;

public class kill : MonoBehaviour
{
    public TextMeshProUGUI taunt;
    public Animator dollAnimator;

    public enum LightState
    {
        Green,
        Red
    }

    public LightState currentState;

    float timer;

    public bool canKill = false; 

    void Start()
    {
        StartCoroutine(StateLoop());
    }

    IEnumerator StateLoop()
    {
        while (true)
        {
     
            SetState(LightState.Red);
            canKill = false;

            yield return new WaitForSeconds(Random.Range(3f, 4f));

        
            taunt.text = "..." ;
            yield return new WaitForSeconds(0.6f);

            SetState(LightState.Green);

       
            yield return new WaitForSeconds(0.5f);
            canKill = true;

            yield return new WaitForSeconds(Random.Range(2.5f, 3.5f));
        }
    }

    void SetState(LightState newState)
    {
        currentState = newState;

        if (newState == LightState.Green)
        {
            taunt.text = "GREEN - DON'T MOVE!";
            dollAnimator.SetBool("IsGreen", true);
        }
        else
        {
            taunt.text = "RED - MOVE!";
            dollAnimator.SetBool("IsGreen", false);
        }
    }
}