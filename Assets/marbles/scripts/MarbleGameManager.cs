using System.Collections.Generic;
using UnityEngine;

public class MarbleGameManager : MonoBehaviour
{
    int hiddenSquares;

    public int correctGuesses = 0;
    public int wrongGuesses = 0;

    [Header("Prefabs")]
    public GameObject marblePrefab;
    public GameObject fakePrefab;

    [Header("Box Settings")]
    public Transform spawnArea;
    public Vector3 spawnSize = new Vector3(2f, 2f, 2f);
    public Transform lid;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        EnemyHideSquares();
    }

    public void EnemyHideSquares()
    {
        ClearOld();

        int totalObjects = Random.Range(1, 6); 

        for (int i = 0; i < totalObjects - 1; i++)
        {
            Spawn(marblePrefab);
        }

        
        Spawn(fakePrefab);

        hiddenSquares = totalObjects - 1;

        CloseLid();

        Debug.Log("New round started.");
    }

    void Spawn(GameObject prefab)
    {
        Vector3 pos = spawnArea.position + new Vector3(
            Random.Range(-spawnSize.x / 2, spawnSize.x / 2),
            Random.Range(-spawnSize.y / 2, spawnSize.y / 2),
            Random.Range(-spawnSize.z / 2, spawnSize.z / 2)
        );

        GameObject obj = Instantiate(prefab, pos, Random.rotation);
        spawnedObjects.Add(obj);
    }

    void ClearOld()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    public void PlayerGuess(int guess)
    {
        Debug.Log("Player guessed: " + guess);

        OpenLid(); 

        if (guess == hiddenSquares)
        {
            correctGuesses++;
            Debug.Log(" Correct! Total correct guesses: " + correctGuesses);
        }
        else
        {
            wrongGuesses++;
            Debug.Log("Wrong! (You counted the fake, didn’t you?)");
        }

        CheckWin();

        Invoke(nameof(EnemyHideSquares), 2f);  }

    void CheckWin()
    {
        if (correctGuesses >= 3)
        {
            Debug.Log(" Player wins! 3 correct guesses achieved.");
        }
    }

    void OpenLid()
    {
        if (lid != null)
            lid.localRotation = Quaternion.Euler(-110f, 0, 0);
    }

    void CloseLid()
    {
        if (lid != null)
            lid.localRotation = Quaternion.Euler(0, 0, 0);
    }
}