using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [Space]
    [SerializeField] private float distance = 70f;


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

                if (commItem != null&& Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
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
