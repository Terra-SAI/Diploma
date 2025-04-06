using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// родительский
public class GameManager : MonoBehaviour
{
    protected static GameManager instanse;
    public static T GetInstance<T>() where T : GameManager
    {
        return instanse as T;
    }
    protected virtual void Awake() => instanse = this;

    //public static AudioManager Audio;

    public void Pause() => Time.timeScale = 0f;
    public void Unpause() => Time.timeScale = 1f;

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Quit() => Application.Quit();
}
