using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window_GM : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject windowCamera;
    [Space]
    public GameObject windowObj;
    public GameObject targetPosition;
    [Space]
    [SerializeField] private GameObject continueButton;

    public bool isWindowDone = false;

    private void Start()
    {
        continueButton.SetActive(false);
    }
    void Update()
    {
        if (isWindowDone) return;
        if (targetPosition.transform.position == windowObj.transform.position)
        {
            isWindowDone = true;           
            continueButton.SetActive(true);
        }
    }

    public void LoadMainScene()
    {

        cameraManager.isOnWindow = false;

        cameraManager.Switch(windowCamera, cameraMain);
        continueButton.SetActive(false);
    }


}
