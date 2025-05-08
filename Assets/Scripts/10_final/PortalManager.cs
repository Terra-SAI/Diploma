using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 101, 102, 103, 104 };

    [Space]
    [SerializeField] private GameObject mainCamera;

    [Space]
    [SerializeField] private GameObject altar;
    // Start is called before the first frame update
    void Start()
    {
        altar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.HasItemsWithIds(requiredItemIds))
        {
            altar.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            { 
                var commItem = hit.collider.GetComponent<PortItem>();

                if (commItem != null)
                {
                    if (inventoryManager.HasItemsWithIds(requiredItemIds))
                    {
                       // SaveManager.Instance.ResetSave();
                        SceneManager.LoadScene("12_Dancing");
                    }
                    else 
                    { 
                        commItem.ActivateComment();
                    }
                }
            }
        }
    }
}
