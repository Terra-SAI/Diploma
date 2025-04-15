using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void Switch(GameObject offCamera, GameObject onCamera)
    {
        offCamera.SetActive(false);
        onCamera.SetActive(true);
    }
}
