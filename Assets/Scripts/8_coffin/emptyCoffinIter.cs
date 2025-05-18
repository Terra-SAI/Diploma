using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyCoffinIter : MonoBehaviour
{
    public dialog_new_trigger dialog;
    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private CamManager cameraManager;
    [Space]
    [SerializeField] private float distance = 70f;
    void Update()
    {
        if (!cameraManager.isOnMain) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<deadItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    StartDialog();
                }
            }
        }
    }
    private void StartDialog()
    {
        dialog.TriggerDialogue();
    }
}
