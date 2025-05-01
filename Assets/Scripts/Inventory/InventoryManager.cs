using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [HideInInspector]
    public List<Item> item;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode pickupKey = KeyCode.Mouse0; 
    private Item nearbyItem; 

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

        if (nearbyItem != null && Input.GetKeyDown(pickupKey)) 
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
              // Debug.Log(hit.collider.name);
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Item"))
        {
            nearbyItem = collision.GetComponent<Collider>().GetComponent<Item>();
        //  Debug.Log($"nearby: {nearbyItem.name}");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (nearbyItem == collision.GetComponent<Collider>().GetComponent<Item>())
            {
                nearbyItem = null;
              //Debug.Log("no nearby");
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

            if (!found) 
            {
                return false;
            }
        }

        return true; 
    }

    public int CountItemsWithIds(int id)
    { 
     int count = 0;
        List<int> ids = new List<int>(id);
        if (HasItemsWithIds(ids))
        {
            foreach (Item i in item)
            {
                if (i.id == id)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
