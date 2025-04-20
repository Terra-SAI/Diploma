using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WashingIter : MonoBehaviour
{
    public dialog_new_trigger dialog;

    [SerializeField] private Item book;

    [SerializeField] private Washing_GM Washing_GM;
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject washingCamera;

    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> {4};

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<WashingItem>();

                if (commItem != null)
                {
                    if (Washing_GM.isWashing) return;
                    if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    {
                        CamManager.Switch(mainCamera, washingCamera);
                        CamManager.isOnWash = true;
                        inventoryManager.RemoveItem(book);
                    }
                    else
                    {
                        StartDialog();
                    }
                }
            }
        }
    }
    private void StartDialog()
    {
        dialog.TriggerDialogue();
    }
}
