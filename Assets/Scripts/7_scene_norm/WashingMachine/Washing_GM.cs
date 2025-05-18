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
    [HideInInspector]
    public bool isOn = false;
    [HideInInspector]
    public bool isStarted = false;
    [HideInInspector]
    public int count = 1;

    public bool isWashing = false;
    public bool isActive = false;

    [Space]
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject result;

    [Space]
    [SerializeField] private GameObject onButton;
    [SerializeField] private GameObject startButton;

    private void Start()
    {
        result.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isWashing) { return; }
        if (!cameraManager.isOnWash) return;
        isActive = true;
        instructions.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        if (!isOn)
        {
            isStarted = false;
            //  EnableEmission(onButton);
        }
        else if (isOn)
        {
            EnableEmission(onButton);
            if (count != targetNum)
            {
                // EnableEmission(onButton);
                isStarted = false;
            }
            else if (isStarted)
            {
                EnableEmission(startButton);
                isStarted = true;
                isWashing = true;
                result.gameObject.SetActive(true);
                instructions.gameObject.SetActive(false);
                // instructions.gameObject.SetActive(true);
            }
        }
    }
    public void LoadMainScene()
    {
        
        cameraManager.isOnMain = true;
        cameraManager.isOnWash = false;
        result.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(washingCamera, cameraMain);

    }

    public void EnableEmission(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", mat.color * (-0.7f));
        }
    }

}
