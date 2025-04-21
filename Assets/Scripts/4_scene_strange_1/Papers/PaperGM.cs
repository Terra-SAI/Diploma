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

    private bool isPaperDone = false;
    private void Start()
    {
        continueButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPaperDone) return;

        if (objectSpawner.isPaired)
        {
            isPaperDone = true;
            continueButton.gameObject.SetActive(true);
            papers.gameObject.SetActive(false);
        }
    }

    public void LoadMainScene()
    {
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(paperCamera, mainCamera);

    }
}
