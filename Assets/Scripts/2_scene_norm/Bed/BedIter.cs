using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedIter : MonoBehaviour
{
    public dialog_new_trigger dialog1;
    public dialog_new_trigger dialog2;
    [Space]
    [SerializeField] private Washing_GM Washing_GM;
    [SerializeField] private Window_GM Window_GM;
    [SerializeField] private LampGM Lamp_GM;
    [SerializeField] private SwitcherIter Switcher_GM;


   [Space]
    [SerializeField] private GameObject mainCamera;

    //[Space]
    //public bool canSleep = false;
    //public bool isLightOn = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<BedItem>();

                if (commItem != null)
                {
                    if (Washing_GM.isWashing && Window_GM.isWindowDone)
                    {
                        if (Lamp_GM.isLightOff2 && Switcher_GM.isLightOff1)
                        {
                            SceneManager.LoadScene("empty");
                        }
                        else StartDialog(dialog2);
                    }
                    else
                    {
                        // ≈сли не можно пройти, запускаем диалог
                        StartDialog(dialog1);
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
