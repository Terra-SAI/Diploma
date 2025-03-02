using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // �����
    [SerializeField] private float minX = -5f; // ����������� �������
    [SerializeField] private float maxX = 5f; // ������������ �������
    [SerializeField] private float smoothSpeed = 5f; // �������� ����������� �������� ������

    private float fixedY; // ������������� �������� Y
    private float fixedZ; // ������������� �������� Z

    void Start()
    {
        fixedY = transform.position.y; // ���������� Y, ����� �� �� �������
        fixedZ = transform.position.z; // ���������� Z, ���� ����� �������������
    }

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(player.position.x, minX, maxX); // ��������� ������ �� X

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, fixedY, fixedZ), smoothSpeed * Time.deltaTime);
    }

}

