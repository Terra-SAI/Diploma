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
  //  public Collider doorCollider; // Коллайдер двери
    private bool playerNearby = false; // Флаг, чтобы знать, что игрок рядом с дверью
    [SerializeField] private List<int> requiredItemIds = new List<int> { 1, 2 };
   

    private void Start()
    {
        //doorCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        // Проверяем, нажата ли ЛКМ и игрок рядом с дверью
        if (playerNearby && Input.GetMouseButtonDown(0)) // ЛКМ = 0
        {
            if (inventoryManager.HasItemsWithIds(requiredItemIds) && dishManager.isFinished)
            {
                // Если можно пройти, снимаем коллайдер с двери
                SceneManager.LoadScene(2);
            }
            else
            {
                // Если не можно пройти, запускаем диалог
                StartDialog();
            }
        }
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
