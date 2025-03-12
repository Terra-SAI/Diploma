using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
   // [SerializeField] private float rotationSpeed = 50f;

    // void Update()
    // {
    // Вращаем тарелку вокруг оси Y при нажатии клавиш Q и E
    //   if (Input.GetKey(KeyCode.Q))
    // {
    //    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    // }
    //if (Input.GetKey(KeyCode.E))
    //    {
    //    transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    //  }
    // }

    private bool isRotating = false;  // Флаг, который будет отслеживать, вращается ли тарелка
    private float targetAngle = 0f;  // Целевой угол, на который мы хотим повернуть тарелку
    [SerializeField] private float rotationSpeed = 5f;  // Скорость вращения тарелки

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши (ЛКМ)
        if (Input.GetMouseButtonDown(0))  // 0 — это ЛКМ
        {
            // Устанавливаем целевой угол (180 градусов относительно текущего положения)
            targetAngle = Mathf.Repeat(transform.eulerAngles.y + 180f, 360f);  // Поворачиваем на 180 градусов
            isRotating = true;  // Начинаем вращение
        }

        // Если тарелка должна вращаться
        if (isRotating)
        {
            // Плавно вращаем тарелку с использованием Lerp
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);  // Вращаем тарелку вдоль оси Y

            // Если тарелка почти достигла целевого угла, останавливаем вращение
            if (Mathf.Abs(currentAngle - targetAngle) < 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
