using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCleaner : MonoBehaviour
{
    private Material dirtMaterial;
    public float eraseSpeed = 0.1f; // Скорость стирания грязи

    void Start()
    {
        // Получаем материал тарелки
        Renderer renderer = GetComponent<Renderer>();
       // plateMaterial = GetComponent<Renderer>().material;
        Material[] materials = renderer.materials;
        dirtMaterial = materials[1];
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sponge") && dirtMaterial != null)
        {
            Debug.Log("Губка чистит тарелку!");

            // Получаем текущий цвет грязи
            Color currentColor = dirtMaterial.color;

            // Уменьшаем альфа-канал (делаем грязь прозрачной)
            float newAlpha = Mathf.Max(currentColor.a - eraseSpeed * Time.deltaTime, 0f);

            // Применяем новый цвет
            dirtMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}
