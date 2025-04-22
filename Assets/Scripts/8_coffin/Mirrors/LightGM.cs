using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LightGM : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject lightCamera;
    [Space]
    [SerializeField] private LightMovement move;
    [Space]
    [SerializeField] private GameObject MaryOld;
    [SerializeField] private GameObject MaryNew;

    [Space]
    [SerializeField] private GameObject continueButton;

    public bool isAlive = false;

    private void Start()
    {
        MaryOld.gameObject.SetActive(true);
        MaryNew.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        isAlive = false;
    }
    void Update()
    {
        if (isAlive) return;

        if (move.isAlive)
        {
            MaryOld.gameObject.SetActive(false);
            MaryNew.gameObject.SetActive(true);

            continueButton.gameObject.SetActive(true);
            isAlive = true;
        }
    }

    public void LoadMainScene()
    {
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(lightCamera, cameraMain);

    }
}
