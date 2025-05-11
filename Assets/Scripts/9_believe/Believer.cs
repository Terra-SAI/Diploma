using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Believer : MonoBehaviour
{
    [SerializeField] private int normalParam = 30;
    public void DoBelieve()
    {
        SaveManager.Instance.AddToProgress(normalParam);
        SaveManager.Instance.SaveGame("10_Final", SaveManager.Instance.GetProgress());
        SceneManager.LoadScene("10_Final");
    }

    public void DoNotBelieve()
    {
        SaveManager.Instance.AddToProgress(-1*normalParam);
        SaveManager.Instance.SaveGame("10_Final", SaveManager.Instance.GetProgress());
        SceneManager.LoadScene("10_Final");
    }
}
