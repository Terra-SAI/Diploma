using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red"))
        {
            Destroy(other.gameObject, 3f); // Удаляем, если упало мимо
        }
    }
}
