using UnityEngine;

public class GuessButton : MonoBehaviour
{
    public int guessNumber;
    public MarbleGameManager manager;

    public void Guess()
    {
        manager.PlayerGuess(guessNumber);
    }
}