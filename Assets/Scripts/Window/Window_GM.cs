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
    [SerializeField] private GameObject windowBase;
    [SerializeField] private GameObject newPos;
    [Space]
    [SerializeField] private GameObject continueButton;

    public bool isWindowDone = false;


    private void Start()
    {
        continueButton.gameObject.SetActive(false);
    }
    void Update()
    {
            if (isWindowDone)  return; 

        if (targetPosition.transform.position == windowObj.transform.position)
        {
            windowBase.transform.position = newPos.transform.position;
            isWindowDone = true;           
            continueButton.gameObject.SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        cameraManager.isOnMain = true;
        cameraManager.isOnWindow = false;
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(windowCamera, cameraMain); 
    }


}
