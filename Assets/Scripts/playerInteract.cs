using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private CamManager cameraManager;

    private Interaclable previousInteractable;

    // Update is called once per frame
    void Update()
    {
        if (!cameraManager.isOnMain) return;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            var interaclable = hit.collider.GetComponent<Interaclable>();

            // ≈сли навели на новый интерактивный объект
            if (interaclable != null)
            {
                if (interaclable != previousInteractable)
                {
                    if (previousInteractable != null)
                    {
                        previousInteractable.OnHoverExit();
                    }

                    interaclable.OnHoverEnter();
                    previousInteractable = interaclable;
                }
                // если курсор на том же объекте Ч ничего не делаем
            }
            else
            {
                // если наводим на что-то неинтерактивное Ч выключаем подсветку предыдущего
                if (previousInteractable != null)
                {
                    previousInteractable.OnHoverExit();
                    previousInteractable = null;
                }
            }
        }
        else
        {
            // если никуда не попали Ч тоже отключаем подсветку
            if (previousInteractable != null)
            {
                previousInteractable.OnHoverExit();
                previousInteractable = null;
            }
        }
    }
}
