using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    private GameObject currentTooltip; // Текущая подсказка
    private CommItem nearbyObject; // Объект, с которым игрок столкнулся
    [SerializeField] private float tooltipTimer = 5f; // Время в секундах, через которое панель скрывается
    private float currentTime = 0f; // Текущий таймер

    void Update()
    {
        if (nearbyObject != null) // Если объект в радиусе
        {
            if (Input.GetMouseButtonDown(0)) // ЛКМ
            {
                // Клик по объекту
                if (nearbyObject.tooltipUI != null)
                {
                    // Переключаем состояние подсказки
                    currentTooltip = nearbyObject.tooltipUI;
                    currentTooltip.SetActive(!currentTooltip.activeSelf);
                    Debug.Log("Подсказка изменена.");

                    // Если подсказка включена, начинаем отсчет времени
                    if (currentTooltip.activeSelf)
                    {
                        currentTime = tooltipTimer; // Сброс таймера
                    }
                }
            }

            // Если подсказка активна и время вышло — выключаем её
            if (currentTooltip != null && currentTooltip.activeSelf)
            {
                currentTime -= Time.deltaTime; // Отсчитываем время

                if (currentTime <= 0f)
                {
                    currentTooltip.SetActive(false);
                    Debug.Log("Подсказка автоматически скрыта.");
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Comment"))
        {
            nearbyObject = collision.collider.GetComponent<CommItem>();
            if (nearbyObject != null)
            {
                Debug.Log($"Столкнулись с объектом с подсказкой: {nearbyObject.name}");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Comment"))
        {
            if (nearbyObject != null && collision.collider.GetComponent<CommItem>() == nearbyObject)
            {
                nearbyObject = null;
                Debug.Log("Вышли из зоны объекта с подсказкой.");
            }
        }
    }

}
