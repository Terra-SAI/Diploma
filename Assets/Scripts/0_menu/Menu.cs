using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject menu;

    [Space]
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject cont;
    [SerializeField] private GameObject tut;
    [SerializeField] private GameObject exit;

    private void Start()
    {
        tutorial.SetActive(false);
        menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(start);
        EventSystem.current.SetSelectedGameObject(cont);
        EventSystem.current.SetSelectedGameObject(tut);
        EventSystem.current.SetSelectedGameObject(exit);
    }

    public void StartGame()
    {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene("01_Tut");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    public void LoadGame ()
    {
        SaveManager.Instance.LoadGame();
    }

    public void TutorialOn()
    {
        tutorial.SetActive(true);
        menu.SetActive(false);
    }
    public void TutorialOff()
    {
        tutorial.SetActive(false);
        menu.SetActive(true);
    }
}
