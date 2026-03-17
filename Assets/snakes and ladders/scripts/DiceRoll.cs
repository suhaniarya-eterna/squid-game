using UnityEngine;
using UnityEngine.InputSystem;


public class DiceRoll : MonoBehaviour
{
    public PlayerMovement player;

    void Update()
    {
         if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            player.RollDice();
        }
    }
}