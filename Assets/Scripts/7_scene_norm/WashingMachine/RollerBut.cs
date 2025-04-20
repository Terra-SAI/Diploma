using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBut : MonoBehaviour
{
    [SerializeField] private Camera washingCamera;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private List<GameObject> panels = new();

    private int count = 0;

    private void Start()
    {
        int i;
        panels[0].SetActive(true);
        for (i = 1; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = washingCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    panels[count].SetActive(false);
                    count++;
                    if (count > 8) count = count - 9;
                    panels[count].SetActive(true);
                    gameManager.GetComponent<Washing_GM>().count = count + 1;
                }
            }
        }
    }
}
