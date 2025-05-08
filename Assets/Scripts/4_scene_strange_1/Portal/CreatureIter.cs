using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureIter : MonoBehaviour
{
    [SerializeField] private dialog_new_trigger dialogNew;
    [SerializeField] private dialog_new_trigger dialogOld;

    [Space]
    [SerializeField] private GameObject portal;
    // UI диалога

    [Space]
    [SerializeField] private Camera camera;

    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 5 };
    [SerializeField] private Item diamond;

    [Space]
    [SerializeField] private float distance = 70f;
    bool isPortal = false;

    private void Start()
    {
        portal.SetActive(false);
        isPortal = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<CreatureItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (isPortal) StartDialog(dialogNew);
                    else if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    {
                        inventoryManager.RemoveItem(diamond);
                        StartDialog(dialogNew);
                        portal.SetActive(true);
                        isPortal = true;
                    }
                    else
                    {
                        StartDialog(dialogOld);
                    }
                }
            }
        }
    }

    private void StartDialog(dialog_new_trigger dialog)
    {
        dialog.TriggerDialogue();
    }
}
