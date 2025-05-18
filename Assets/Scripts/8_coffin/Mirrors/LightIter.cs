using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightIter : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;
    public dialog_new_trigger dialog;
    [Space]
    [SerializeField] private Item mirror1;
    [SerializeField] private Item mirror2;
    [SerializeField] private Item mirror3;

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
        if (!CamManager.isOnMain) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
    
            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<LightItem>();

                if (commItem != null&& Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (gm.isActive)
                    {
                        CamManager.isOnMain = false;
                        CamManager.isOnMirror = true;
                        CamManager.Switch(mainCamera, lightCamera);
                    }
                    else if (inventoryManager.CountItemsWithIds(requiredItemIds[0]) == 3)
                    {
                        gm.isActive = true;
                        inventoryManager.RemoveItem(mirror1);
                        inventoryManager.RemoveItem(mirror2);
                        inventoryManager.RemoveItem(mirror3);
                       
                    }
                    else 
                    {
                        dialog.TriggerDialogue();
                    }
                }
            }
        }
    }
}
