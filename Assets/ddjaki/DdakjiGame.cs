using UnityEngine;

public class DdakjiGame : MonoBehaviour
{
    public GameObject enemyTile;

    public void FlipAttempt()
    {
        Debug.Log("Player attempted flip!");

        float chance = Random.value;

        if(chance > 0.5f)
        {
            Debug.Log("✅ Tile flipped! Player wins.");

            enemyTile.transform.Rotate(180,0,0);
        }
        else
        {
            Debug.Log("❌ Flip failed.");
        }
    }
}