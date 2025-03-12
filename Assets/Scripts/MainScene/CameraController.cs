using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Игрок
    [SerializeField] private float minX = -5f; // Минимальная граница
    [SerializeField] private float maxX = 5f; // Максимальная граница
    [SerializeField] private float smoothSpeed = 5f; // Скорость сглаживания движения камеры

    private float fixedY; // Фиксированное значение Y
    private float fixedZ; // Фиксированное значение Z

    void Start()
    {
        fixedY = transform.position.y; // Запоминаем Y, чтобы он не менялся
        fixedZ = transform.position.z; // Запоминаем Z, если нужно зафиксировать
    }

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(player.position.x, minX, maxX); // Двигаемся только по X

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, fixedY, fixedZ), smoothSpeed * Time.deltaTime);
    }

}

