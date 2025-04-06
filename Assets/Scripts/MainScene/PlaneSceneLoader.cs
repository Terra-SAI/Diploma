using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneSceneLoader : MonoBehaviour
{
    [SerializeField] private CamManager camManager;
    [SerializeField] private GameObject dishCamera;
    [SerializeField] private GameObject mainCamera;
   // [SerializeField] private Transform player;  // Игрок
  //  [SerializeField] private float interactionRadius = 3f;  // Радиус, на котором можно взаимодействовать с тарелкой
    private bool playerNearby = false; // Флаг, чтобы знать, что игрок рядом с дверью

    void Update()
    {
        //// Проверка, в радиусе ли игрок
        //float distance = Vector3.Distance(player.position, transform.position);
        //if (distance <= interactionRadius)
        //{
        //    canInteract = true;
        //}
        //else
        //{
        //    canInteract = false;
        //}

        // Если игрок в радиусе и нажимает ЛКМ, то переходим на другую сцену
        if (playerNearby && Input.GetMouseButtonDown(0)) 
        {
            TransitionToScene();  // Функция перехода на другую сцену
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Dish"))
        {
            Debug.Log("We are in");
            // Если игрок подошел к двери, активируем флаг
            playerNearby = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Dish"))
        {
            // Если игрок покидает область двери, сбрасываем флаг
            playerNearby = false;
        }
    }

    // Функция для перехода на другую сцену
    private void TransitionToScene()
    {
        camManager.Switch(mainCamera, dishCamera);
        camManager.isOnDish = true;
    }

}
