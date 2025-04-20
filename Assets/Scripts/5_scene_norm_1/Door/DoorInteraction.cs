using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private GameManagerDish dishManager;
    [SerializeField] private Window_GM Window_GM;

    [Space]
    public dialog_new_trigger dialog; // UI диалога

    [Space]
    [SerializeField] private Camera camera;

    [Space]
    public bool canPass = false;
    
    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 1, 2 };
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<DoorItem>();

                if (commItem != null)
                {
                    if (inventoryManager.HasItemsWithIds(requiredItemIds) && dishManager.isFinished && Window_GM.isWindowDone)
                    {
                        // ≈сли можно пройти, снимаем коллайдер с двери
                        SceneManager.LoadScene("06_Dialogue");
                    }
                    else
                    {
                        // ≈сли не можно пройти, запускаем диалог
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
