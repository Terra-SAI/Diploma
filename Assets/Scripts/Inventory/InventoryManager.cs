using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [HideInInspector]
    public List<Item> item;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode pickupKey = KeyCode.Mouse0; // Клавиша для подбора предметов
    private Item nearbyItem; // Ссылка на предмет, который можно подобрать

    void Start()
    {
        item = new List<Item>();
        cellContainer.SetActive(false);

        NumItems();

        for (int i = 1; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }
    void NumItems()
    {
        for (int i = 1; i < cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }
    }

            void Update()
    {
        ToggleInventory();

        if (nearbyItem != null && Input.GetKeyDown(pickupKey)) // ЛКМ
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var invItem = hit.collider.GetComponent<Item>();

                if (invItem != null)
                {
                    AddItemToInventory(invItem);
                }
                nearbyItem = null;
            }
        }
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            cellContainer.SetActive(!cellContainer.activeSelf);
        }
    }

    public void AddItemToInventory(Item newItem)
    {
        for (int i = 1; i < item.Count; i++)
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

    public void RemoveItem(Item item)
    {
        this.item.Remove(item);
        DisplayItem();
    }

    public  void DisplayItem()
    {
        for (int i = 1; i < item.Count; i++)
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

    public bool HasItemsWithIds(List<int> itemIds)
    {
        foreach (int id in itemIds)
        {
            bool found = false;
            foreach (Item i in item)
            {
                if (i.id == id)
                {
                    found = true;
                    break;
                }
            }

            if (!found) // Если хотя бы одного предмета нет, возвращаем false
            {
                return false;
            }
        }

        return true; // Все предметы с нужными ID найдены
    }
}
