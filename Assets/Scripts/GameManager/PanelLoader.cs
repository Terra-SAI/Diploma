using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelLoader : MonoBehaviour
{
    private bool playerNearby = false;

    private void Update()
    {
        // Проверяем, нажата ли ЛКМ и игрок рядом с дверью
        if (playerNearby && Input.GetMouseButtonDown(0)) // ЛКМ = 0
        {
            SceneManager.LoadScene(5);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            Debug.Log("We are in");
            // Если игрок подошел к двери, активируем флаг
            playerNearby = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            // Если игрок покидает область двери, сбрасываем флаг
            playerNearby = false;
        }
    }
}
