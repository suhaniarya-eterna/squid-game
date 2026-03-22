using UnityEngine;
using System.Collections;

public class TileEffect : MonoBehaviour
{
    public enum TileType
    {
        Ladder,
        FakeLadder,
        ReverseLadder,
        Snake,
        MegaSnake
    }

    public TileType tileType;

    public int targetTile;
    public int halfwayTile;

    public IEnumerator Activate(PlayerMovement player)
    {
        switch (tileType)
        {
            case TileType.Ladder:
                
                yield return player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.ReverseLadder:

                yield return player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.Snake:
                yield return player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.MegaSnake:
                
                yield return player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.FakeLadder:
                Debug.Log("Fake Ladder triggered");
                yield return player.StartCoroutine(FakeClimb(player));
                break;
        }
    }

    IEnumerator FakeClimb(PlayerMovement player)
    {
        Debug.Log("Fake climb to tile " + halfwayTile);

        yield return player.StartCoroutine(player.MoveToTile(halfwayTile));

        yield return new WaitForSeconds(1f);

        Debug.Log("Falling to tile " + targetTile);

        yield return player.StartCoroutine(player.MoveToTile(targetTile));
    }
}