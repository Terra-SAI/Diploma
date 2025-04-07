using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DishLoader : MonoBehaviour
{
    private bool canActivate = false;
    [SerializeField] private CamManager camManager;
    [SerializeField] private GameObject dishCamera;
    [SerializeField] private GameObject mainCamera;

    public void LoadDishes()
    {
        if (canActivate)
        {
            camManager.Switch(mainCamera, dishCamera);
            camManager.isOnDish = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
