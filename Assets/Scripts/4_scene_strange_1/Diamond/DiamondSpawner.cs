using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    [SerializeField] private ElectricLock electricLock;

    [Space]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject diamond;

    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 5 };

    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false);
        diamond.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.HasItemsWithIds(requiredItemIds))
        {
            return;
        }
        if (electricLock.isCodeCorrect) 
        {
            panel.gameObject.SetActive(true);
            diamond.gameObject.SetActive(true);
        }
    }
}
