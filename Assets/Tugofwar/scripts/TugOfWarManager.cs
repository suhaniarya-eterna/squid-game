using UnityEngine;

public class TugOfWarManager : MonoBehaviour
{
    public Transform rope;

    public float playerForce = 0;
    public float enemyForce = 0;

    public float moveSpeed = 2f;

    void Update()
    {
        enemyForce += Random.Range(0f, 0.2f);

        float forceDifference = playerForce - enemyForce;

        rope.position += new Vector3(forceDifference * moveSpeed * Time.deltaTime, 0, 0);

        CheckWin();
    }

    public void PlayerPull()
    {
        playerForce += 1f;
        Debug.Log("Player pulled rope!");
    }

    void CheckWin()
    {
        if (rope.position.x > 5)
        {
            Debug.Log("🏆 Player Team Wins!");
        }

        if (rope.position.x < -5)
        {
            Debug.Log("💀 Enemy Team Wins!");
        }
    }
}