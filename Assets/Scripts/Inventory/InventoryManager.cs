using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    List<Item> item;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode pickupKey = KeyCode.Mouse0; // Клавиша для подбора предметов
    private Item nearbyItem; // Ссылка на предмет, который можно подобрать

    void Start()
    {
        item = new List<Item>();
        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    void Update()
    {
        ToggleInventory();

        // Проверяем, если есть предмет рядом и нажата клавиша
        if (nearbyItem != null && Input.GetKeyDown(pickupKey))
        {
            AddItemToInventory(nearbyItem);
            nearbyItem = null; // Сбрасываем ссылку после подбора
        }
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            cellContainer.SetActive(!cellContainer.activeSelf);
        }
    }

    void AddItemToInventory(Item newItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == 0)
            {
                item[i] = newItem;
                DisplayItem();
                Destroy(newItem.gameObject);
                break;
            }
        }
    }

    void DisplayItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            nearbyItem = collision.collider.GetComponent<Item>();
            Debug.Log($"Рядом предмет: {nearbyItem.name}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            if (nearbyItem == collision.collider.GetComponent<Item>())
            {
                nearbyItem = null;
                Debug.Log("Вышли из зоны предмета");
            }
        }
    }
}
