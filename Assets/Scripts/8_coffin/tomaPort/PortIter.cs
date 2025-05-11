using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortIter : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [Space]
    [SerializeField] private GameObject keys;
    [SerializeField] private GameObject cap_old;
    [SerializeField] private GameObject cap_new;

    [Space]
    [SerializeField] private GameObject textPanel;

    [Space]
    [SerializeField] private float distance = 70f;

    private int count = 0;


    private void Start()
    {
        cap_old.SetActive(true);
        cap_new.SetActive(false);
        keys.SetActive(false);
        textPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // À Ã
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.TryGetComponent<PortItem>(out PortItem commItem) && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    commItem.ActivateComment();
                    keys.SetActive(true);
                    cap_new.SetActive(true);
                    cap_old.SetActive(false);
                    if (count < 1)
                    {
                        StartText();
                        count++;
                    }
                  
                }
            }
        }
    }
    private void StartText()
    {
        textPanel.SetActive(true);
        Invoke("HideText", 5f);
    }
    private void HideText()
    {
        textPanel.SetActive(false);
    } 
}


