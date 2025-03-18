using UnityEngine;

public class EventClick : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

    [SerializeField]
    ScenesManager scenesManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetPanelState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetPanelState(false);
        }
    }

    private void SetPanelState(bool state)
    {
        Panel.SetActive(state);

    }

    public void LoadMiniGame()
    {
        scenesManager.EndLevel(EndResult.MINIGAME);
    }

}
