using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private GameManagerDish dishManager;
    public InventoryManager inventoryManager;
    public dialog_new_trigger dialog; // UI диалога
    public bool canPass = false;
    [SerializeField] private Camera camera;
    private bool playerNearby = false; // Флаг, чтобы знать, что игрок рядом с дверью
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
                    if (inventoryManager.HasItemsWithIds(requiredItemIds) && dishManager.isFinished)
                    {
                        // Если можно пройти, снимаем коллайдер с двери
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        // Если не можно пройти, запускаем диалог
                        StartDialog();
                    }
                }
            }
        }
        //// Проверяем, нажата ли ЛКМ и игрок рядом с дверью
        //if (playerNearby && Input.GetMouseButtonDown(0)) // ЛКМ = 0
        //{
        //    if (inventoryManager.HasItemsWithIds(requiredItemIds) && dishManager.isFinished)
        //    {
        //        // Если можно пройти, снимаем коллайдер с двери
        //        SceneManager.LoadScene(1);
        //    }
        //    else
        //    {
        //        // Если не можно пройти, запускаем диалог
        //        StartDialog();
        //    }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            Debug.Log("We are in");
            // Если игрок подошел к двери, активируем флаг
            playerNearby = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            // Если игрок покидает область двери, сбрасываем флаг
            playerNearby = false;
        }
    }


    private void StartDialog()
    {
        // Включаем UI для диалога (или любой другой метод для запуска диалога)
        dialog.TriggerDialogue();
    }
}
