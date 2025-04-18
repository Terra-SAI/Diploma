using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washing_GM : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject washingCamera;

    [Space]
    [SerializeField] private int targetNum = 5;
   // [HideInInspector]
    public bool isOn = false;
   // [HideInInspector]
    public bool isStarted = false;
   // [HideInInspector]
    public int count = 1;
  

    [Space]
    [SerializeField] private GameObject continueButton;

    private void Start()
    {
        continueButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isOn) isStarted = false;
        else if (count != targetNum) isStarted = false;
    }
    public void LoadMainScene()
    {
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(washingCamera, cameraMain);

    }

}
