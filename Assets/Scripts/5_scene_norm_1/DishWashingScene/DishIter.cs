using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishIter : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject dishCamera;

    [Space]
    [SerializeField] private float distance = 70f;
    // [Space] public InventoryManager inventoryManager;
    //[SerializeField] private List<int> requiredItemIds = new List<int> { 3 };


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<dishItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    CamManager.Switch(mainCamera, dishCamera);
                    CamManager.isOnDish = true;
                    CamManager.isOnMain = false;
                }
            }
        }
    }
}
