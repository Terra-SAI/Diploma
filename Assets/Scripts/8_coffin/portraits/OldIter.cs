using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldIter : MonoBehaviour
{
    [SerializeField] private Camera camera;

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
                if (hit.collider.TryGetComponent<OldItem>(out OldItem commItem))
                {
                    if (commItem.count == 1)
                    { 
                    commItem.oldP.SetActive(false);
                        commItem.backP.SetActive(true);
                        commItem.heart.SetActive(true);
                        return;
                    }
                    commItem.count++;
                    commItem.ActivateComment();
                }
            }
        }
    }
}
