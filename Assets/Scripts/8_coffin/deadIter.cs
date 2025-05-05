using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadIter : MonoBehaviour
{
    [Space]
    [SerializeField] private int normalParam = -2;

    public dialog_new_trigger dialog;
    [Space]
    [SerializeField] private GameObject mainCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<CommItemNew>();

                if (commItem != null)
                {
                    SaveManager.Instance.AddToProgress(normalParam);
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
