using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureIter1 : MonoBehaviour
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

    int count = 0;


    private void Start()
    {
        portal.SetActive(false);
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

                if (commItem != null)
                {
                    if (count >= 1)
                    {
                        inventoryManager.RemoveItem(diamond);
                        StartDialog(dialogNew);
                        portal.SetActive(true);
                        
                    }
                    else
                    {
                        StartDialog(dialogOld);
                        count++;
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
