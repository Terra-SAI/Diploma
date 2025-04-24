using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject pauseButton;

    private void Start()
    {
        panel.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Pause(GameManager gameManager)
    {
        panel.SetActive(true);
        pauseButton.SetActive(false);
        gameManager.Pause();
            
    }
   public void Resume(GameManager gameManager)
    {
        panel.SetActive(false);
        pauseButton.SetActive(true);
        gameManager.Unpause();
        
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("00_Menu");
    }
}
