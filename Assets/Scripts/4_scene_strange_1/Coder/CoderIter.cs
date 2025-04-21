using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoderIter : MonoBehaviour
{

    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject coderCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<CoderItem>();

                if (commItem != null)
                {
                    CamManager.isOnCoder = true;
                    CamManager.Switch(mainCamera, coderCamera);
                }
            }
        }
    }
}
