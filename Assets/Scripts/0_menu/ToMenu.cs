using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public void ToMenuBut()
    {
        SceneManager.LoadScene("00_Menu");
    }
}
