using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneSceneLoader : MonoBehaviour
{
    [SerializeField] private Transform player;  // Игрок
    [SerializeField] private float interactionRadius = 3f;  // Радиус, на котором можно взаимодействовать с тарелкой
    private bool canInteract = false;  // Флаг, показывающий, можно ли нажимать на тарелку

    void Update()
    {
        // Проверка, в радиусе ли игрок
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionRadius)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }

        // Если игрок в радиусе и нажимает ЛКМ, то переходим на другую сцену
        if (canInteract && Input.GetMouseButtonDown(0))  // 0 — это ЛКМ
        {
            TransitionToScene();  // Функция перехода на другую сцену
        }
    }

    // Функция для перехода на другую сцену
    private void TransitionToScene()
    {
        // Здесь заменяешь "NextScene" на название сцены, на которую нужно перейти
        SceneManager.LoadScene("DishWashing");
    }

}
