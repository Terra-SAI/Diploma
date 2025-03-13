using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCleaner : MonoBehaviour
{
    private Material dirtMaterial;
    public float eraseSpeed = 0.1f; // �������� �������� �����

    void Start()
    {
        // �������� �������� �������
        Renderer renderer = GetComponent<Renderer>();
       // plateMaterial = GetComponent<Renderer>().material;
        Material[] materials = renderer.materials;
        dirtMaterial = materials[1];
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sponge") && dirtMaterial != null)
        {
            Debug.Log("����� ������ �������!");

            // �������� ������� ���� �����
            Color currentColor = dirtMaterial.color;

            // ��������� �����-����� (������ ����� ����������)
            float newAlpha = Mathf.Max(currentColor.a - eraseSpeed * Time.deltaTime, 0f);

            // ��������� ����� ����
            dirtMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}
