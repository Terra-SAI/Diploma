using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OutFromTut : MonoBehaviour
{
    [SerializeField] private GameObject tut;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(tut);
    }
    public void outFromTut() 
    {
        SaveManager.Instance.SaveGame("04_StrangeScene", SaveManager.Instance.GetProgress());
        SceneManager.LoadScene("04_StrangeScene");
    }
}
