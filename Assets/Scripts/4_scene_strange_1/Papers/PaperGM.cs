using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PaperGM : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject paperCamera;

    [Space]
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private GameObject papers;
    [Space]
    [SerializeField] private GameObject continueButton;

    public bool isPaperDone = false;
    private void Start()
    {
        continueButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPaperDone) return;
       if (cameraManager.isOnPaper) continueButton.gameObject.SetActive(true);
        if (objectSpawner.isPaired)
        {
            isPaperDone = true;
            
            papers.gameObject.SetActive(false);
        }
    }

    public void LoadMainScene()
    {
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(paperCamera, mainCamera);
        cameraManager.isOnPaper = false;
        cameraManager.isOnMain = true;

    }
}
