using UnityEngine;
using TMPro;
using System.Collections;

public class SquidIntroTaunter : MonoBehaviour
{
    [Header("Taunt Text")]
    public TextMeshProUGUI tauntText;
    public float textFadeDuration = 0.4f;

    [Header("Taunts")]
    public string[] taunts = new string[]
    {
        "Welcome. 🦑",
        "Think you're built for this?",
        "Last guy cried. Just saying.",
        "Good luck lil bro LMAOOO"
    };

    [Header("Timing")]
    public float timeBetweenTaunts = 2.5f;

    void Start()
    {
        tauntText.alpha = 0;
        StartCoroutine(PlayTaunts());
    }

    IEnumerator PlayTaunts()
    {
        foreach (string taunt in taunts)
        {
            yield return StartCoroutine(ShowText(taunt));
            yield return new WaitForSeconds(timeBetweenTaunts);
            yield return StartCoroutine(HideText());
        }

        tauntText.gameObject.SetActive(false); // hide UI when done
    }

    IEnumerator ShowText(string message)
    {
        tauntText.text = message;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / textFadeDuration;
            tauntText.alpha = t;
            yield return null;
        }
    }

    IEnumerator HideText()
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime / textFadeDuration;
            tauntText.alpha = t;
            yield return null;
        }
    }
}