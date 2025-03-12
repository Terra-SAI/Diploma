using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCleaner : MonoBehaviour
{
    private Material plateMaterial;
    public float eraseSpeed = 0.1f; // �������� �������� �����

    void Start()
    {
        // �������� �������� �������
        plateMaterial = GetComponent<Renderer>().material;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sponge"))
        {
            Debug.Log("����� �������� �������!");
            // �������� ������� �����-����� ��������� �����
            Color currentColor = plateMaterial.color;
            // ������� �����-����� (������ ����� ����������)
            float newAlpha = Mathf.Max(currentColor.a - eraseSpeed * Time.deltaTime, 0f);
            plateMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}
