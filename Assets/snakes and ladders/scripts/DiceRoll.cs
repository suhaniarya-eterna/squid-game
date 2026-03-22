using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject stuff;

    void Start()
    {
        if (gameObject.activeSelf)
        {
            stuff.SetActive(false);
        }
    }

    public void RollDiceButton()
    {
        
        if (player.IsMoving()) return;

        player.RollDice();
    }
}