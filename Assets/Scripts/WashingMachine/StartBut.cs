using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBut : MonoBehaviour
{
    [SerializeField] private Camera washingCamera;
    [SerializeField] private GameObject gameManager;

    private Renderer buttonRenderer;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = washingCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    gameManager.GetComponent<Washing_GM>().isStarted = true;
                   // EnableEmission();
                }
            }
        }
    }

    public void EnableEmission()
    {
        if (buttonRenderer == null) return;

        foreach (var mat in buttonRenderer.materials)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", mat.color * (-0.7f));
        }
    }
}
