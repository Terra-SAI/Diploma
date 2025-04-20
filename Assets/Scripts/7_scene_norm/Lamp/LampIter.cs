using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampIter : MonoBehaviour
{
    [SerializeField] private LampGM LampGM;
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject lampCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<LampItem>();

                if (commItem != null)
                {
                    if (LampGM.isLightOff2) return;
                    CamManager.isOnLamp = true;
                    CamManager.Switch(mainCamera, lampCamera);
                }
            }
        }
    }
}
