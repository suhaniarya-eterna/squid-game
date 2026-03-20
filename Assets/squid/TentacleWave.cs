using UnityEngine;

public class TentacleWave : MonoBehaviour
{
    public Transform[] bones;

    [Header("Wave Settings")]
    public float speed = 2f;
    public float amplitude = 15f;
    public float frequency = 2f;

    [Header("Wave Offset")]
    public float delayBetweenBones = 0.2f;

    [Header("Randomness")]
    public float noiseAmount = 2f;

    private Quaternion[] initialRotations;

    void Start()
    {
        initialRotations = new Quaternion[bones.Length];

        for (int i = 0; i < bones.Length; i++)
        {
            initialRotations[i] = bones[i].localRotation;
        }
    }

    void Update()
    {
        float time = Time.time * speed;

        for (int i = 0; i < bones.Length; i++)
        {
            float wave = Mathf.Sin(time * frequency - i * delayBetweenBones);

            float noise = Random.Range(-noiseAmount, noiseAmount);

            float angle = wave * amplitude + noise;

            bones[i].localRotation = initialRotations[i] * Quaternion.Euler(0, 0, angle);
        }
    }
}