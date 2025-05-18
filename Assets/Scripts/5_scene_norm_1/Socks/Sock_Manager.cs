using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sock_Manager : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject sockCamera;

    [Space]
    [SerializeField] private GameObject sockSelecter;
    [Space]
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject textResult;
    [Space]
    [SerializeField] private GameObject inventoryManager;

    [Space]
    [SerializeField] private Item item;
    private int i = 1;
    private bool isContinued = false;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.gameObject.SetActive(false);
        textResult.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cameraManager.isOnSocks) return;
        if (!isContinued)
        {
            continueButton.gameObject.SetActive(true);
            if (sockSelecter.GetComponent<SockSelector>().isSockFind)
            {
                if (i > 0)
                {
                    textResult.gameObject.SetActive(true);
                    inventoryManager.GetComponent<InventoryManager>().AddItemToInventory(item);
                    i--;
                    isContinued = true;
                }
            }
        }
    }

    public void LoadMainScene()
    {
        cameraManager.isOnMain = true;
        cameraManager.isOnSocks = false;
        textResult.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        cameraManager.Switch(sockCamera, cameraMain);
    }

}
