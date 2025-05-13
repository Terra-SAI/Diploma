using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldIter : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [Space]
    [SerializeField] private float distance = 70f;

    // private int count = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // À Ã
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider.TryGetComponent<OldItem>(out OldItem commItem) && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    //if (commItem.count == 2)
                    //{ 
                    //commItem.oldP.SetActive(false);
                    //    commItem.backP.SetActive(true);
                    //    commItem.heart.SetActive(true);
                    //    return;
                    //}
                    //commItem.count++;
                    commItem.ActivateComment();
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) // À Ã
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider.TryGetComponent<OldItem>(out OldItem commItem) && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    //if (commItem.count == 2)
                    //{
                        commItem.oldP.SetActive(false);
                        commItem.backP.SetActive(true);
                        commItem.heart.SetActive(true);
                        //return;
                    //}
                    //commItem.count++;
                    //commItem.ActivateComment();
                }
            }
        }
    }
}
