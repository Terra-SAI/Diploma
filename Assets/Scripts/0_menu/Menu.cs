using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SaveManager.Instance.ResetSave();
        SceneManager.LoadScene("04_StrangeScene");
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
}
