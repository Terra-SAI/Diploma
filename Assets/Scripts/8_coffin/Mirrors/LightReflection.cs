using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflection : MonoBehaviour
{

    [SerializeField] private Transform target; // Целевая точка
    [SerializeField] private Transform[] mirrors; // Массив зеркал
    [SerializeField] private GameObject lightBeamPrefab;
    [SerializeField] private float mirrorMoveDistance = 3f; // Расстояние, на которое зеркала могут двигаться

    private GameObject lightBeam;
    private Vector3 currentDirection; // Направление луча

    void Start()
    {
        currentDirection = transform.forward; // Начальный вектор направления

        // Создаем спрайт луча
        lightBeam = Instantiate(lightBeamPrefab, transform.position, Quaternion.identity);
        lightBeam.SetActive(false); // Спрайт не виден изначально
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 startPosition = transform.position; // Позиция источника света

        // Проверяем, если луч столкнется с чем-то
        if (Physics.Raycast(startPosition, currentDirection, out hit))
        {
            lightBeam.SetActive(true); // Активируем спрайт луча
            lightBeam.transform.position = startPosition + (currentDirection * hit.distance / 2); // Позиционируем спрайт
            lightBeam.transform.localScale = new Vector3(1, hit.distance, 1); // Растягиваем спрайт по длине луча
            lightBeam.transform.up = currentDirection; // Устанавливаем угол спрайта в соответствии с направлением луча

            // Отражение от зеркала
            if (hit.collider.CompareTag("Mirror"))
            {
                Vector3 reflectedDirection = Vector3.Reflect(currentDirection, hit.normal); // Отражаем луч
                currentDirection = reflectedDirection; // Направление луча обновляется
            }
        }
        else
        {
            lightBeam.SetActive(false); // Если луч не попадал в объект, скрываем спрайт
        }

        // Проверка попадания в целевую точку
        CheckIfHitTarget(startPosition + currentDirection * 10f); // Проверка на большой дистанции
    }

    // Проверка попадания в целевую точку
    void CheckIfHitTarget(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(hitPoint, target.position);
        if (distance < 0.5f) // Если расстояние маленькое, засчитываем попадание
        {
            Debug.Log("Hit the target!");
        }
    }
}
