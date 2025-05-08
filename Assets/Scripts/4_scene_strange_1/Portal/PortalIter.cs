using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalIter : MonoBehaviour
{
    [Space]
    [SerializeField] private float distance = 70f;
    [SerializeField] private GameObject mainCamera;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<PortalItem>();


                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    SaveManager.Instance.SaveGame("05_RoomScene", SaveManager.Instance.GetProgress());
                    SceneManager.LoadScene("05_RoomScene");
                }
            }
        }
    }
}
