using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCleaner : MonoBehaviour
{
    private Material plateMaterial;
    public float eraseSpeed = 0.1f; // Скорость стирания грязи

    void Start()
    {
        // Получаем материал тарелки
        plateMaterial = GetComponent<Renderer>().material;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sponge"))
        {
            Debug.Log("Губка касается тарелки!");
            // Получаем текущий альфа-канал материала грязи
            Color currentColor = plateMaterial.color;
            // Снижаем альфа-канал (делаем грязь прозрачной)
            float newAlpha = Mathf.Max(currentColor.a - eraseSpeed * Time.deltaTime, 0f);
            plateMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}
