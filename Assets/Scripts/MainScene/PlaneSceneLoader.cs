using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneSceneLoader : MonoBehaviour
{
    [SerializeField] private Transform player;  // �����
    [SerializeField] private float interactionRadius = 3f;  // ������, �� ������� ����� ����������������� � ��������
    private bool canInteract = false;  // ����, ������������, ����� �� �������� �� �������

    void Update()
    {
        // ��������, � ������� �� �����
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionRadius)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }

        // ���� ����� � ������� � �������� ���, �� ��������� �� ������ �����
        if (canInteract && Input.GetMouseButtonDown(0))  // 0 � ��� ���
        {
            TransitionToScene();  // ������� �������� �� ������ �����
        }
    }

    // ������� ��� �������� �� ������ �����
    private void TransitionToScene()
    {
        // ����� ��������� "NextScene" �� �������� �����, �� ������� ����� �������
        SceneManager.LoadScene("DishWashing");
    }

}
