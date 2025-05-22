using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_walking : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private Animator animator;
    [Space]
    [SerializeField] private CamManager camManager;

    private int currentTargetIndex = 0;
    private int direction = 1; // 1 — вперёд, -1 — назад

    void Start()
    {
        if (points.Length > 0)
        {
            transform.position = points[0].position;
            currentTargetIndex = 1;
            animator.SetBool("isMoving", true);
        }
    }

    void Update()
    {
        if (camManager.isOnDialog)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        if (points.Length < 2) return;

        Transform targetPoint = points[currentTargetIndex];

        // Перемещение к текущей точке
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Определение направления и поворот
        Vector3 directionToTarget = targetPoint.position - transform.position;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        // Проверка достижения цели
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Проверка на край маршрута
            if (currentTargetIndex == 0 || currentTargetIndex == points.Length - 1)
            {
                // Случайно меняем направление
                direction = Random.value < 0.5f ? 1 : -1;
            }

            currentTargetIndex += direction;

            // Гарантия, что индекс не выйдет за пределы
            currentTargetIndex = Mathf.Clamp(currentTargetIndex, 0, points.Length - 1);

            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }
}
