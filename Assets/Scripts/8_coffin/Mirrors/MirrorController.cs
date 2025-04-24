using UnityEngine;

public class MirrorController : MonoBehaviour
{
    private bool isDragging = false; // Перемещается ли зеркало
    [SerializeField] private float minY = -3111f;
    [SerializeField] private float maxY = -3068f;

    [SerializeField] private float moveSpeed = 2f; // Скорость перемещения зеркала
    [SerializeField] private Camera camera;

    [Space]
    [SerializeField] private LightMovement move;
    private Vector3 offset;

    void Update()
    {
        if (move.isAlive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
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
            float targetY = (mouseWorldPos + offset).y;

            // Ограничиваем движение в пределах minX и maxX
            float clampedY = Mathf.Clamp(targetY, minY, maxY);

            transform.position = new Vector3(
                transform.position.x,
                clampedY,
                transform.position.z
            );
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(camera.transform.position, transform.position);
        return camera.ScreenToWorldPoint(mousePos);
    }
}
