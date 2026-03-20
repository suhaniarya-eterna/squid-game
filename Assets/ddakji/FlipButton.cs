using UnityEngine;

public class FlipButton : MonoBehaviour
{
    public DdakjiGame game;

    public void Flip()
    {
        game.FlipAttempt();
    }
}