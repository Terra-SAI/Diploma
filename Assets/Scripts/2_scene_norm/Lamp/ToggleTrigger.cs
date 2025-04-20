using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleTrigger : MonoBehaviour
{
    [SerializeField] private Camera lampCamera;
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 1f;

    private bool isDragging = false;
    private Vector3 offset;

    public bool isDown = false;

    [HideInInspector]
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = lampCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                if (hit.transform == transform)
                {
                    Debug.Log("I am dragging");
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
            float targetY = (mouseWorldPos + offset).y;

            // Ограничиваем движение в пределах minY и maxY
            float clampedY = Mathf.Clamp(targetY, minY, maxY);

            transform.position = new Vector3(
                transform.position.x,
                clampedY,
                transform.position.z
            );
        }
        if (transform.position.y == minY) isDown = true;
        else isDown = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(lampCamera.transform.position, transform.position);
        return lampCamera.ScreenToWorldPoint(mousePos);
    }
}
