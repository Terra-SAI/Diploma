using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpongeController : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Transform plate;  // ������ �� ������� ��� ������������� � ������� Z
    [SerializeField] private float offset = 5.0f;
    [SerializeField] private Vector3 rightBottomPosition = new Vector3(5f, -5f, 0f);  // ������� �������

    void Start()
    {
        mainCamera = Camera.main;
        transform.position = rightBottomPosition;
    }

    void Update()
    {                  
            // ���������� ���������� �� ������ �� �������
            float distanceToPlate = Mathf.Abs(plate.position.z - mainCamera.transform.position.z);

            // �������� ������� ���� � ������������� Z ��� ScreenToWorldPoint
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceToPlate;

            // ������������ � ������� ����������
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            

        if (Input.GetMouseButtonDown(0))  // ���
        {
            Vector3 targetPosition = new Vector3(rightBottomPosition.x, rightBottomPosition.y, rightBottomPosition.z);
            transform.position = targetPosition;

        }
        else transform.position = new Vector3(worldPos.x, worldPos.y, plate.position.z + offset);

    }
}
