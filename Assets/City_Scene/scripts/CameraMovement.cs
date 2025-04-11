using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player; // Игрок
    [SerializeField] private float minZ = -5f; // Минимальная граница
    [SerializeField] private float maxZ = 5f; // Максимальная граница
    [SerializeField] private float smoothSpeed = 5f; // Скорость сглаживания движения камеры

    private float fixedY; // Фиксированное значение Y
    private float fixedX; // Фиксированное значение Z

    void Start()
    {
        fixedY = transform.position.y; // Запоминаем Y, чтобы он не менялся
        fixedX = transform.position.x; // Запоминаем Z, если нужно зафиксировать
    }

    void LateUpdate()
    {
        float targetZ = Mathf.Clamp(player.position.z, minZ, maxZ); // Двигаемся только по X

        transform.position = Vector3.Lerp(transform.position, new Vector3(fixedX, fixedY, targetZ), smoothSpeed * Time.deltaTime);
    }
}
