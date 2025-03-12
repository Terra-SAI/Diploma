using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpongeController : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Transform plate;  // Ссылка на тарелку для использования её позиции Z
    [SerializeField] private float offset = 5.0f;
    [SerializeField] private Vector3 rightBottomPosition = new Vector3(5f, -5f, 0f);  // Целевая позиция

    void Start()
    {
        mainCamera = Camera.main;
        transform.position = rightBottomPosition;
    }

    void Update()
    {                  
            // Определяем расстояние от камеры до тарелки
            float distanceToPlate = Mathf.Abs(plate.position.z - mainCamera.transform.position.z);

            // Получаем позицию мыши и устанавливаем Z для ScreenToWorldPoint
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceToPlate;

            // Конвертируем в мировые координаты
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            

        if (Input.GetMouseButtonDown(0))  // ЛКМ
        {
            Vector3 targetPosition = new Vector3(rightBottomPosition.x, rightBottomPosition.y, rightBottomPosition.z);
            transform.position = targetPosition;

        }
        else transform.position = new Vector3(worldPos.x, worldPos.y, plate.position.z + offset);

    }
}
