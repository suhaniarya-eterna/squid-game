using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vote : MonoBehaviour
{
    public TextMeshProUGUI msg;
    public float delay = 2.5f;
    public bool voted = false;
    public GameObject stuff;
    private bool active = false;
    public void Yes()
    {
        if (voted) return;
        voted = true;

        StartCoroutine(YesNext());
    }
    public void No()
    {
        if (voted) return;
        voted = true;

        StartCoroutine(NoNext());
    }
    public void Update()
    {
        if(gameObject.activeSelf == true )
        {
            active = true;
        }
        if (active)
        {
            stuff.SetActive(false);
        }
        if(!voted && active)
        {
            msg.gameObject.SetActive(false);}
        if(voted && active)
        {
            msg.gameObject.SetActive(true);
        }
    }

    IEnumerator NoNext()
    {
        msg.text = "There ain't no democracy.";
        yield return new WaitForSeconds(1.5f);

        msg.text = "Quit is a four letter word.";
        yield return new WaitForSeconds(1.5f);

        msg.text = "You leaving is my choice, not yours.";
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }IEnumerator YesNext()
    {
        msg.text = "Let’s see how long you’ll be fine.";
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}