using UnityEngine;

public class MarbleGameManager : MonoBehaviour
{
    int hiddenSquares;

    public int correctGuesses = 0;
    public int wrongGuesses = 0;

    public void EnemyHideSquares()
    {
        hiddenSquares = Random.Range(1, 6);
        Debug.Log("Enemy has hidden squares (1–5).");
    }

    public void PlayerGuess(int guess)
    {
        Debug.Log("Player guessed: " + guess);

        if (guess == hiddenSquares)
        {
            correctGuesses++;
            Debug.Log("✅ Correct! Total correct guesses: " + correctGuesses);
        }
        else
        {
            wrongGuesses++;
            Debug.Log("❌ Wrong guess.");
        }

        CheckWin();

        EnemyHideSquares(); // start next round automatically
    }

    void CheckWin()
    {
        if (correctGuesses >= 3)
        {
            Debug.Log("🏆 Player wins! 3 correct guesses achieved.");
        }
    }
}