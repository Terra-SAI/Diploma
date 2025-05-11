using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableSock : MonoBehaviour
{
  //  [SerializeField] private CamManager cameraManager;

    [SerializeField] private float fixedY = 0f;
    [SerializeField] private Vector2 moveAreaMin;
    [SerializeField] private Vector2 moveAreaMax;

 //   [SerializeField] private Material highlightMaterial;

    // [SerializeField] private
    public GameObject sockCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private bool moved = false;
    private Vector3 initialMousePosition;
    private Material[] originalMaterials;
    private Renderer sockRenderer;

    void Start()
    {
      //  cameraManager.isOnSocks = false;
        sockRenderer = GetComponentInChildren<Renderer>();
        if (sockRenderer != null)
        {
            originalMaterials = sockRenderer.materials;
        }
    }

    void OnMouseDown()
    {
     //   if (!cameraManager.isOnSocks) return;
        isDragging = true;
        moved = false;
        initialMousePosition = GetMouseWorldPosition();

        Vector3 mouseWorldPos = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
     //   if (!cameraManager.isOnSocks) return;
        if (!isDragging) return;

        Vector3 currentMousePos = GetMouseWorldPosition();
        if (Vector3.Distance(initialMousePosition, currentMousePos) > 0.01f)
        {
            moved = true;
        }

        Vector3 newPosition = currentMousePos + offset;
        newPosition.y = fixedY;
        newPosition.x = Mathf.Clamp(newPosition.x, moveAreaMin.x, moveAreaMax.x);
        newPosition.z = Mathf.Clamp(newPosition.z, moveAreaMin.y, moveAreaMax.y);

        transform.position = newPosition;
    }

    void OnMouseUp()
    {
      //  if (!cameraManager.isOnSocks) return;
        if (!moved)
        {
            EnableEmission();
            FindObjectOfType<SockSelector>().SelectSock(gameObject);
        }

        isDragging = false;
    }

    public void EnableEmission()
    {
        if (sockRenderer == null) return;

        foreach (var mat in sockRenderer.materials)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", mat.color * 1.5f);
        }
    }

    public void DisableEmission()
    {
        if (sockRenderer == null) return;

        foreach (var mat in sockRenderer.materials)
        {
            mat.DisableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = sockCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }
}
