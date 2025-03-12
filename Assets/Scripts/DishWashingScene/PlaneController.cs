using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
   // [SerializeField] private float rotationSpeed = 50f;

    // void Update()
    // {
    // ������� ������� ������ ��� Y ��� ������� ������ Q � E
    //   if (Input.GetKey(KeyCode.Q))
    // {
    //    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    // }
    //if (Input.GetKey(KeyCode.E))
    //    {
    //    transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    //  }
    // }

    private bool isRotating = false;  // ����, ������� ����� �����������, ��������� �� �������
    private float targetAngle = 0f;  // ������� ����, �� ������� �� ����� ��������� �������
    [SerializeField] private float rotationSpeed = 5f;  // �������� �������� �������

    void Update()
    {
        // ���������, ���� �� ������ ����� ������ ���� (���)
        if (Input.GetMouseButtonDown(0))  // 0 � ��� ���
        {
            // ������������� ������� ���� (180 �������� ������������ �������� ���������)
            targetAngle = Mathf.Repeat(transform.eulerAngles.y + 180f, 360f);  // ������������ �� 180 ��������
            isRotating = true;  // �������� ��������
        }

        // ���� ������� ������ ���������
        if (isRotating)
        {
            // ������ ������� ������� � �������������� Lerp
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);  // ������� ������� ����� ��� Y

            // ���� ������� ����� �������� �������� ����, ������������� ��������
            if (Mathf.Abs(currentAngle - targetAngle) < 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
