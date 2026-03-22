using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class detectplayermovement : MonoBehaviour
{
    public Animator animplayer;
    public TextMeshProUGUI die;
    public kill gameController;

    public GameObject stuff;

    Vector3 lastPosition;
    float movementThreshold = 0.01f;

    bool isDead = false;

    void Start()
    {
        animplayer = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (isDead) return;

        die.gameObject.SetActive(false);

        if (gameObject.activeSelf)
        {
            stuff.SetActive(false);
        }

        float movement = Vector3.Distance(transform.position, lastPosition);

        if (movement > movementThreshold)
        {
         
            if (gameController.currentState == kill.LightState.Green && gameController.canKill)
            {
                Die();
            }
        }

        lastPosition = transform.position;
    }

    void Die()
{
    isDead = true;

    Debug.Log("Player Eliminated!");
    die.gameObject.SetActive(true);
    die.text = "You were caught moving!";

    var movement = GetComponent<StarterAssets.ThirdPersonController>();
    if (movement) movement.enabled = false;


    var controller = GetComponent<CharacterController>();
    if (controller) controller.enabled = false;


    var input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
    if (input) input.enabled = false;

    StartCoroutine(DeathSequence());
}

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(3f); // let animation breathe
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}