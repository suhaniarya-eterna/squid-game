using UnityEngine;
using Unity.Cinemachine;

public class CameraIntroMover : MonoBehaviour
{
    private CinemachineSplineDolly splineDolly;
    public float duration = 8f;
    public GameObject gameObjects; // drag player parent here

    private float elapsed = 0f;
    private bool completed = false;

    void Awake()
    {
        if (gameObjects != null)
            gameObjects.SetActive(false);
    }

    void Start()
    {
        splineDolly = GetComponent<CinemachineSplineDolly>();
        splineDolly.CameraPosition = 0f;
    }

    void Update()
    {
        if (elapsed < duration && !completed)
        {
            elapsed += Time.deltaTime;
            splineDolly.CameraPosition = Mathf.Lerp(0f, 1f, elapsed / duration);
        }
        else if (!completed)
        {
            completed = true;
            if (gameObjects != null)
                gameObjects.SetActive(true);
        }
    }
}