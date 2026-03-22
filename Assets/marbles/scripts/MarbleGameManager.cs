using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarbleGameManager : MonoBehaviour
{
    int hiddenSquares;
    public TextMeshProUGUI taunt;

    public int correctGuesses = 0;
    public int wrongGuesses = 0;

    [Header("Prefabs")]
    public GameObject marblePrefab;
    public GameObject fakePrefab;

    private bool active = false;
    public GameObject stuff;

    [Header("Box Settings")]
    public Transform spawnArea;
    public Transform lid;

    [Header("Grid Settings")]
    public float spacing = 0.4f;
    public int perRow = 2;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        EnemyHideSquares();
    }

    public void EnemyHideSquares()
    {
        ClearOld();

        int totalObjects = Random.Range(1, 6); // max 5

        SpawnObjects(totalObjects);

        hiddenSquares = totalObjects - 1;

        CloseLid();

        Debug.Log("New round started.");
    }

    void SpawnObjects(int totalObjects)
{
    int index = 0;

    for (int i = 0; i < totalObjects; i++)
    {
        int row = index / perRow;
        int col = index % perRow;

        // 🔥 controlled height (no skyscraper)
        float height = row * (spacing * 0.4f); 

        Vector3 pos = spawnArea.position + new Vector3(
            (col - (perRow - 1) / 2f) * spacing,
            height,
            0
        );

        // slight randomness so it doesn't look robotic
        pos += new Vector3(
            Random.Range(-0.05f, 0.05f),
            0,
            Random.Range(-0.05f, 0.05f)
        );

        GameObject prefab = (i == totalObjects - 1) ? fakePrefab : marblePrefab;

        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        spawnedObjects.Add(obj);

        index++;
    }
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
            taunt.text = "Correct! Total correct guesses: " + correctGuesses;
        }
        else
        {
            wrongGuesses++;
            taunt.text = "Wrong! (You counted the fake, didn’t you?)\nTotal wrong guesses: " + wrongGuesses;
        }

        CheckWin();

        Invoke(nameof(EnemyHideSquares), 2f);
    }

    void CheckWin()
    {
        if (correctGuesses >= 3)
        {
            taunt.text = "You guessed right! Congrats on surviving this.";
        }
    }

    void OpenLid()
     { 
        if (lid != null) 
     lid.localPosition = new Vector3(-15f, 0, 0);
      } 
    
    void CloseLid() 
    { if (lid != null) 
    lid.localPosition = new Vector3(189.429f, 7.220133f, 180.813f); 
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            active = true;
        }

        if (active)
        {
            stuff.SetActive(false);
        }
    }
}