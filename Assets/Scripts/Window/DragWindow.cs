using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWindow : MonoBehaviour
{
    [SerializeField] private CamManager window;
    [SerializeField] private Camera windowCamera;
    [SerializeField] private float minX = -3111f;
    [SerializeField] private float maxX = -3068f;

    private bool isDragging = false;
    private Vector3 offset;

   
    void Update()
    {
        if (!window.isOnWindow) { return;  }
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = windowCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    offset = transform.position - GetMouseWorldPosition();
                    
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            float targetX = (mouseWorldPos + offset).x;

            // Ограничиваем движение в пределах minX и maxX
            float clampedX = Mathf.Clamp(targetX, minX, maxX);

            transform.position = new Vector3(
                clampedX,
                transform.position.y,
                transform.position.z
            );
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(windowCamera.transform.position, transform.position);
        return windowCamera.ScreenToWorldPoint(mousePos);
    }
}
