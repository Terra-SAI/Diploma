using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   // public bool isOnDish = false;
    //private static CameraManager _instanse;
    //public static CameraManager Instance
    //{
    //    get
    //    {
    //        if (_instanse == null)
    //        {
    //            Debug.Log("CameraController does not exist in scene!");
    //        }
    //        return _instanse;
    //    }
    //}
    //private void Awake() => _instanse = this;

    [SerializeField] private GameObject primaryCamera;
    [SerializeField] private GameObject[] cameras;

    //void Start()
    //{
    //    SwitchToCamera(primaryCamera);
    //}

    public void SwitchToCamera(GameObject targetCamera)
    {
        if (targetCamera == primaryCamera)
        {
            primaryCamera.SetActive(true);
            return;
        }
        //foreach (GameObject camera in cameras)
        //{
        //if (camera == targetCamera)
        //{
        else
        {
            primaryCamera.SetActive(false);
            //Debug.Log("Camera is off");
            targetCamera.SetActive(true);
        }
            //}
           // camera.enabled = camera == targetCamera;
       // }
    }
}