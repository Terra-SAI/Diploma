using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LampIter : MonoBehaviour
{
    [SerializeField] private LampGM LampGM;
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject lampCamera;

    [Space]
    [SerializeField] private float distance = 70f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<LampItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (LampGM.isLightOff2) return;
                    CamManager.isOnMain = false;
                    CamManager.isOnLamp = true;
                    CamManager.Switch(mainCamera, lampCamera);
                }
            }
        }
    }
}
