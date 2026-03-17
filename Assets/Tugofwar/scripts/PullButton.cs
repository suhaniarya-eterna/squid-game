using UnityEngine;

public class PullButton : MonoBehaviour
{
    public TugOfWarManager manager;

    public void Pull()
    {
        manager.PlayerPull();
    }
}