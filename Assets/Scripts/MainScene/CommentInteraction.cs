using UnityEngine;

public class CommentInteraction : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private CamManager camManager;
    void Update()
    {
        if (!camManager.isOnMain) return;
            if (Input.GetMouseButtonDown(0)) // À Ã
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            { 
                if (hit.collider.TryGetComponent<CommItem>(out CommItem commItem))
                {
                    commItem.ActivateComment();
                }
            }
        }
    }
}
