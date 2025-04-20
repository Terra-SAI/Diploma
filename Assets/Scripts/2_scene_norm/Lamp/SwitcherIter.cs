using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherIter : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject mainLight;

    public bool isLightOff1 = false;

    private void Start()
    {
        mainLight.SetActive(true);
    }

    void Update()
    {
        if (isLightOff1) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<SwitcherItem>();

                if (commItem != null)
                {
                    mainLight.SetActive(false);
                    isLightOff1 = true;
                }
            }
        }
    }
}
