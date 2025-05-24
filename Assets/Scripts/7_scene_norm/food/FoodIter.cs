using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FoodIter : MonoBehaviour
{
    [SerializeField] private Item snacks;
    [Space] public InventoryManager inventoryManager;
    private List<int> ids;
    private bool isAdded = false;

    [SerializeField] private FoodGM foodGM;
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject foodCamera;

    [Space]
    [SerializeField] private float distance = 70f;

    // Start is called before the first frame update
    void Start()
    {
     
        ids = new List<int> { snacks.id };
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAdded) { inventoryManager.AddItemToInventory(snacks); isAdded = true; }
        if (!CamManager.isOnMain) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<FoodItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (foodGM.isFinished) return;
                    if (inventoryManager.HasItemsWithIds(ids)) inventoryManager.RemoveItem(snacks);
                    CamManager.isOnMain = false;
                    CamManager.Switch(mainCamera, foodCamera);
                    CamManager.isOnFood = true;
                    //if (Washing_GM.isActive)
                    //{
                    //    CamManager.isOnMain = false;
                    //    CamManager.Switch(mainCamera, washingCamera);
                    //    CamManager.isOnWash = true;
                    //}
                    //else if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    //{
                    //    CamManager.isOnMain = false;
                    //    CamManager.Switch(mainCamera, washingCamera);
                    //    CamManager.isOnWash = true;
                    //    inventoryManager.RemoveItem(book);
                    //}
                    //else
                    //{
                    //    StartDialog();
                    //}
                }
            }
        }
    }
}
