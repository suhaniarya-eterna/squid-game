using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscene : MonoBehaviour
{
    private bool active = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true )
        {
            active = true;
        }
        if (active)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
