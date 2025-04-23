using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIter : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject lightCamera;
    [Space]
    [SerializeField] private LightGM gm;

    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 3 };


    // Update is called once per frame
    void Update()
    {
        if (gm.isAlive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
    
            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<LightItem>();

                if (commItem != null)
                {
                    if (inventoryManager.CountItemsWithIds(requiredItemIds[0]) == 3)
                    {
                        CamManager.Switch(mainCamera, lightCamera);
                    }
                }
            }
        }
    }
}
