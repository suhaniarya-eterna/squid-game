using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DdakjiGame : MonoBehaviour
{
    public GameObject enemyTile;
    public GameObject playerTile;

    public TextMeshProUGUI resultText;
    public TextMeshProUGUI money;
    

    public Animator enemytileanim;
    public Animator playertileanim;

    public Camera cam;
    public GameObject stuff;
    public GameObject stuff2;
    public Image flashImage;

    public int playerMoney = 0;

    private bool isPlaying = false;

    private Vector3 camStartPos;
    private Quaternion camStartRot;

    private Vector3 playerStartPos;
    private Vector3 enemyStartPos;

    private Quaternion playerStartRot;
    private Quaternion enemyStartRot;

    void Start()
    {
       
        playertileanim = playerTile.GetComponent<Animator>();
        enemytileanim = enemyTile.GetComponent<Animator>();

        camStartPos = cam.transform.localPosition;
        camStartRot = cam.transform.localRotation;

        playerStartPos = playerTile.transform.localPosition;
        enemyStartPos = enemyTile.transform.localPosition;

        playerStartRot = playerTile.transform.localRotation;
        enemyStartRot = enemyTile.transform.localRotation;

        resultText.text = "Flip the tile!";
        money.text = "Money: 0";

        flashImage.color = new Color(1, 1, 1, 0);
    }

    public void FlipAttempt()
    {
        if (isPlaying) return;

        bool playerWon = Random.value > 0.5f;

        if (playerWon && Random.value < 0.25f)
            playerWon = false;

        StartCoroutine(FlipSequence(playerWon));
    }

    IEnumerator FlipSequence(bool playerWon)
    {
        isPlaying = true;

        ResetTiles();

        yield return new WaitForSeconds(0.05f);

        playertileanim.Rebind();
        enemytileanim.Rebind();

        playertileanim.Update(0);
        enemytileanim.Update(0);

        resultText.text = "...";

        playertileanim.SetTrigger("Flip");

        yield return new WaitForSeconds(0.15f);

        enemytileanim.SetTrigger("enemyflip");

        yield return new WaitForSeconds(0.6f);

        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.15f);


        yield return StartCoroutine(SlapImpact());
        yield return StartCoroutine(ScreenFlash());

        Time.timeScale = 1f;

        yield return new WaitForSeconds(0.2f);

        if (playerWon)
        {
            playerMoney += 100;
            money.text = "Money: " + playerMoney;

            resultText.text = "You won… AND STILL GOT SLAPPED ";

            playerTile.transform.localPosition = new Vector3(0, 0.02f, 0.45f);
        }
        else
        {
            resultText.text = "You lost AND got slapped ";
        }

        yield return new WaitForSeconds(0.6f);

        isPlaying = false;
    }

    void ResetTiles()
    {
        playertileanim.enabled = false;
        enemytileanim.enabled = false;

        playerTile.transform.localPosition = playerStartPos;
        enemyTile.transform.localPosition = enemyStartPos;

        playerTile.transform.localRotation = playerStartRot;
        enemyTile.transform.localRotation = enemyStartRot;

        playertileanim.enabled = true;
        enemytileanim.enabled = true;
    }

    IEnumerator SlapImpact()
    {
        float t = 0f;
        float duration = 0.2f;

        while (t < duration)
        {
            float progress = t / duration;
            float hit = Mathf.Sin(progress * Mathf.PI);

            float x = -0.25f * hit;
            float y = -0.08f * hit;

            cam.transform.localPosition = camStartPos + new Vector3(x, y, 0);

            float tilt = -30f * hit;
            cam.transform.localRotation = Quaternion.Euler(0, 0, tilt);

            t += Time.unscaledDeltaTime;
            yield return null;
        }

        cam.transform.localPosition = camStartPos;
        cam.transform.localRotation = camStartRot;
    }

    IEnumerator ScreenFlash()
    {
        float t = 0;

        while (t < 0.1f)
        {
            float alpha = Mathf.Lerp(0, 0.8f, t / 0.1f);
            flashImage.color = new Color(1, 1, 1, alpha);

            t += Time.unscaledDeltaTime;
            yield return null;
        }

        t = 0;

        while (t < 0.2f)
        {
            float alpha = Mathf.Lerp(0.8f, 0, t / 0.2f);
            flashImage.color = new Color(1, 1, 1, alpha);

            t += Time.unscaledDeltaTime;
            yield return null;
        }

        flashImage.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (isPlaying)
        {
             stuff.SetActive(false);
             stuff2.SetActive(false);

        }
        if (playerMoney >= 1000 && !isPlaying)
        {
            isPlaying = true;
            resultText.text = "You escaped… barely.";
            StartCoroutine(Newscene());
        }
    }

    IEnumerator Newscene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}