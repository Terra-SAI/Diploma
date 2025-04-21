using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperIter : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject paperCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<PaperItem>();

                if (commItem != null)
                {
                    //CamManager.isOnCoder = true;
                    CamManager.Switch(mainCamera, paperCamera);
                }
            }
        }
    }
}
