using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalIter1 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<PortalItem>();

                if (commItem != null)
                {
                    SceneManager.LoadScene("empty");
                }
            }
        }
    }
}
