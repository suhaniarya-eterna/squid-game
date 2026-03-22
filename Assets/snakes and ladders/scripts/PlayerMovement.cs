using UnityEngine;
using System.Collections;
using TMPro;
using StarterAssets;

public class PlayerMovement : MonoBehaviour
{
    public int currentTile = 1;
    public float moveSpeed = 4f;

    public TextMeshProUGUI diceText;
    public TextMeshProUGUI tileText;

    private ThirdPersonController controller;
    private bool isMoving = false;

    void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        UpdateTileText();
    }

    public void RollDice()
    {
        if (isMoving) return;

        int roll = Random.Range(1, 7);

        if (currentTile >= 17)
        {
            roll = Random.Range(1, 3);
        }

        diceText.text = "Dice: " + roll;

        StartCoroutine(MoveSteps(roll));
    }

    IEnumerator MoveSteps(int steps)
    {
        isMoving = true;

        if (controller != null)
            controller.enabled = false;

        for (int i = 0; i < steps; i++)
        {
            int nextTileNumber = currentTile + 1;

            Tile nextTile = GetTile(nextTileNumber);
            if (nextTile == null) break;

            yield return MoveToPosition(nextTile.transform.position);

            currentTile = nextTileNumber;
            UpdateTileText();

            yield return new WaitForSeconds(0.1f);
        }
        Tile landedTile = GetTile(currentTile);

        if (landedTile != null)
        {
            TileEffect effect = landedTile.GetComponent<TileEffect>();

            if (effect != null)
            {
                yield return new WaitForSeconds(0.3f);
                effect.Activate(this);
            }
        }

        if (controller != null)
            controller.enabled = true;

        isMoving = false;
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }

    public IEnumerator MoveToTile(int tileNumber)
    {
        Tile targetTile = GetTile(tileNumber);
        if (targetTile == null) yield break;

        if (controller != null)
            controller.enabled = false;

        yield return MoveToPosition(targetTile.transform.position);

        currentTile = tileNumber;
        UpdateTileText();

        if (controller != null)
            controller.enabled = true;
    }

    Tile GetTile(int number)
    {
        Tile[] tiles = FindObjectsOfType<Tile>();

        foreach (Tile t in tiles)
        {
            if (t.tileNumber == number)
                return t;
        }

        return null;
    }

    void UpdateTileText()
    {
        if (tileText != null)
            tileText.text = "Tile: " + currentTile;
    }
    public bool IsMoving()
{
    return isMoving;
}
}