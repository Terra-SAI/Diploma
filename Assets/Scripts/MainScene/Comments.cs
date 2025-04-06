using UnityEngine;

public class Comments : MonoBehaviour
{
    [SerializeField] private Camera camera;
    void Update()
    {
            if (Input.GetMouseButtonDown(0)) // À Ã
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<CommItem>();

                if (commItem != null)
                {
                    commItem.ActivateComment();
                }
            }
        }
    }
}
