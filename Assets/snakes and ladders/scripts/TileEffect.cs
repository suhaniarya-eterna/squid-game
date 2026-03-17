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

    public void Activate(PlayerMovement player)
    {
        Debug.Log("⚡ Tile effect triggered: " + tileType);

        switch (tileType)
        {
            case TileType.Ladder:
                Debug.Log("🪜 Ladder! Moving player to tile " + targetTile);
                player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.ReverseLadder:
                Debug.Log("🔄 Reverse Ladder! Moving player to tile " + targetTile);
                player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.Snake:
                Debug.Log("🐍 Snake! Sliding player to tile " + targetTile);
                player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.MegaSnake:
                Debug.Log("💀 MEGA SNAKE! Sending player to tile " + targetTile);
                player.StartCoroutine(player.MoveToTile(targetTile));
                break;

            case TileType.FakeLadder:
                Debug.Log("😈 Fake Ladder triggered!");
                player.StartCoroutine(FakeClimb(player));
                break;
        }
    }

    IEnumerator FakeClimb(PlayerMovement player)
    {
        Debug.Log("⬆ Fake climb to tile " + halfwayTile);

        yield return player.StartCoroutine(player.MoveToTile(halfwayTile));

        Debug.Log("⏳ Player thinks they are safe...");

        yield return new WaitForSeconds(1f);

        Debug.Log("💀 Betrayal! Falling to tile " + targetTile);

        yield return player.StartCoroutine(player.MoveToTile(targetTile));
    }
}