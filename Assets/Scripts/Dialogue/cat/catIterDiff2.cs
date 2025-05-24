using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catIterDiff2 : MonoBehaviour
{
    public dialog_new_trigger dialog1;
    public dialog_new_trigger dialog2;
    public dialog_new_trigger dialog3;

    [Space]
    [SerializeField] private CamManager camManager;
    [Space]
    [SerializeField] private GameObject mainCamera;

    [Space]
    [SerializeField] private int[] normals;

    [Space]
    [SerializeField] private float distance = 70f;

    public int num = 0;

    private void Start()
    {
        int[] based = new int[4];
    }

    void Update()
    {
        if (!camManager.isOnMain || camManager.isOnDialog)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<catItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
                    switch (num)
                    {
                        case 0: 
                            {
                                StartDialog(dialog1);
                                //Debug.Log(normals[num]);
                                SaveManager.Instance.AddToProgress(normals[num]);
                                SaveManager.Instance.SaveGame(scene.name, SaveManager.Instance.GetProgress());
                                num++;
                                break;
                            }
                            case 1:
                            {
                                StartDialog(dialog2);
                                //Debug.Log(normals[num]);
                                SaveManager.Instance.AddToProgress(normals[num]);
                                SaveManager.Instance.SaveGame(scene.name, SaveManager.Instance.GetProgress());
                                num++;
                                break;
                            }
                        case 2:
                            {
                                StartDialog(dialog3);
                                // Debug.Log(normals[num]);
                                SaveManager.Instance.AddToProgress(normals[num]);
                                SaveManager.Instance.SaveGame(scene.name, SaveManager.Instance.GetProgress());
                                break;
                            }

                    }
                }
            }
        }
    }
    private void StartDialog(dialog_new_trigger dialog)
    {
        dialog.TriggerDialogue();
    }
}
