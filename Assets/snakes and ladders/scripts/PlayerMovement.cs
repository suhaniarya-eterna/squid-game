using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int currentTile = 0;
    public float moveSpeed = 5f;

    public void RollDice()
    {
        int dice = Random.Range(1, 7);

        Debug.Log("🎲 Dice rolled: " + dice);

        if (currentTile >= 17)
        {
            dice = Random.Range(1, 3);
            Debug.Log("😈 Ragebait activated! Dice reduced to: " + dice);
        }

        StartCoroutine(MoveSteps(dice));
    }

    IEnumerator MoveSteps(int steps)
    {
        Debug.Log("🚶 Player moving " + steps + " steps");

        for (int i = 0; i < steps; i++)
        {
            transform.position += transform.forward * 2f;

            Debug.Log("➡ Step " + (i + 1) + " taken");

            yield return new WaitForSeconds(0.2f);
        }

        Debug.Log("🛑 Movement finished");
    }

    void OnTriggerEnter(Collider other)
    {
        Tile tile = other.GetComponent<Tile>();

        if (tile != null)
        {
            currentTile = tile.tileNumber;

            Debug.Log("📍 Player landed on tile: " + currentTile);

            TileEffect effect = other.GetComponent<TileEffect>();

            if (effect != null)
            {
                Debug.Log("⚙ Tile has effect: " + effect.tileType);
                effect.Activate(this);
            }
        }
    }

    public IEnumerator MoveToTile(int tileNumber)
    {
        Debug.Log("🚀 Moving player to tile: " + tileNumber);

        Tile[] tiles = FindObjectsOfType<Tile>();

        foreach (Tile tile in tiles)
        {
            if (tile.tileNumber == tileNumber)
            {
                Vector3 target = tile.transform.position;

                while (Vector3.Distance(transform.position, target) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(
                        transform.position,
                        target,
                        moveSpeed * Time.deltaTime
                    );

                    yield return null;
                }

                currentTile = tileNumber;

                Debug.Log("✅ Player reached tile: " + currentTile);

                break;
            }
        }
    }
}