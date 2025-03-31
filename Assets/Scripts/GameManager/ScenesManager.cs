using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EndResult
{
    MINIGAME,
    LEVEL_END,
    MINIGAME_END
}

public class ScenesManager : MonoBehaviour
{
    [Header("Game Result Panels")]
    [SerializeField] private GameObject winPanel;
    public void LoadScene()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Loads save file
    /// </summary>
    public static void StartGame()
    {
        string path = Application.persistentDataPath + "/scene.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Processes the game end trigger
    /// </summary>
    /// <param name="endResult"></param>
    public void EndLevel(EndResult endResult)
    {
        switch (endResult)
        {
            case EndResult.LEVEL_END:
                winPanel.SetActive(true);
                break;
            case EndResult.MINIGAME:
                LoadMiniGame();
                break;
            case EndResult.MINIGAME_END:
                LoadLevel();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Returns to main menu
    /// </summary>
    public static void MenuEnd()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads last saved level
    /// </summary>
    public static void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Switches to a mini game
    /// </summary>
    public static void LoadMiniGame()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Closes the application
    /// </summary>
    public static void ExitGame()
    {
        Application.Quit();
    }
}
