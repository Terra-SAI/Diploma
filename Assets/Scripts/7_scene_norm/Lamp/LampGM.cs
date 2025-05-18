using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LampGM : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject lampCamera;
    [Space]
    [SerializeField] private GameObject lamObj;
    [SerializeField] private GameObject lamMesh_diff;
    [SerializeField] private GameObject light_diff;
    [SerializeField] private GameObject lamMesh_base;
    [SerializeField] private GameObject light_base;

    [Space]
    [SerializeField] private GameObject continueButton;

    public bool isLightOff2 = false;

    private void Start()
    {
        continueButton.gameObject.SetActive(false);
        light_diff.SetActive(true);
    }
    void Update()
    {
        if (isLightOff2) return;
        if (!cameraManager.isOnLamp) return;
        continueButton.gameObject.SetActive(true);

        if (lamObj.GetComponent<ToggleTrigger>().isDown)
        {
            light_diff.SetActive(false);
            light_base.SetActive(false);
            Renderer renderer = lamMesh_diff.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material mat = renderer.material;
                mat.DisableKeyword("_EMISSION");
                mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                mat.SetColor("_EmissionColor", Color.black);
            }
            renderer = lamMesh_base.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material mat = renderer.material;
                mat.DisableKeyword("_EMISSION");
                mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                mat.SetColor("_EmissionColor", Color.black);
            }

            isLightOff2 = true;
          //  continueButton.gameObject.SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        cameraManager.isOnMain = true;
        cameraManager.isOnLamp = false;
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(lampCamera, cameraMain);

    }
}
