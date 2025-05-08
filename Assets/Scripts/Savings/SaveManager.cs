using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Awake()
    {
        // Синглтон, чтобы скрипт не дублировался
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(string sceneName, int progressValue)
    {
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.SetInt("ProgressValue", progressValue);
        PlayerPrefs.Save();
        Debug.Log("Игра сохранена: " + sceneName + ", значение: " + progressValue);
    }

    public void LoadGame()
    {
        string sceneName = PlayerPrefs.GetString("LastScene", "01_Tut");
        int progressValue = PlayerPrefs.GetInt("ProgressValue", 0);

        Debug.Log("Загрузка сцены: " + sceneName + ", сохраненное значение: " + progressValue);
        SceneManager.LoadScene(sceneName);
        // А значение можешь применить после загрузки
    }
    public int GetProgress()
    {
        return PlayerPrefs.GetInt("ProgressValue", 0);
    }

    public void SetProgress(int newValue)
    {
        PlayerPrefs.SetInt("ProgressValue", newValue);
        PlayerPrefs.Save();
    }

    public void AddToProgress(int amount)
    {
        int current = GetProgress();
        SetProgress(current + amount);
    }
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("ProgressValue");
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.Save();
        Debug.Log("Сохранения сброшены!");
    }
}
