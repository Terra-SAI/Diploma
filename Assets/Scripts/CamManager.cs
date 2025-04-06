using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public bool isOnDish = false;
    public void Switch(GameObject cam1, GameObject cam2)
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
