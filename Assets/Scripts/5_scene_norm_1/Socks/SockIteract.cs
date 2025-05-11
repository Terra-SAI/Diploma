using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SockIteract : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject sockCamera;

    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 3 };

    [Space]
    [SerializeField] private float distance = 70f;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<dresserItem>();

                if (commItem != null && Vector3.Distance( this.transform.position, commItem.transform.position)<= distance)
                {
                    if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    {
                        return;
                    }
                    else 
                    {
                        CamManager.isOnMain = false;
                        CamManager.isOnSocks = true;
                        CamManager.Switch(mainCamera, sockCamera);
                    }
                }
            }
        }
    }
   
}
