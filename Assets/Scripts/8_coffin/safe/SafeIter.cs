using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeIter : MonoBehaviour
{
    //[SerializeField] private CamManager CamManager;

    [SerializeField] private Item key;
    //[Space]
    [SerializeField] private GameObject mainCamera;
    //[SerializeField] private GameObject safeCamera;
    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 8 };
    [Space]
    [SerializeField] private Item item;
    [SerializeField] private GameObject book;

    [Space]
    [SerializeField] private float distance = 70f;

    private bool isAdded = false;
    private void Start()
    {
        book.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<SafeItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    {
                        if (!isAdded)
                        {
                            // CamManager.Switch(mainCamera, safeCamera);
                            inventoryManager.AddItemToInventory(item);
                            inventoryManager.RemoveItem(key);

                            isAdded = true;
                        }

                        book.gameObject.SetActive(true);

                       // CamManager.isOnWash = true;
                        //inventoryManager.RemoveItem(book);
                    }
                }
            }
        }
    }
    public void OffBook()
    {
        book.gameObject.SetActive(false);
    }
}
