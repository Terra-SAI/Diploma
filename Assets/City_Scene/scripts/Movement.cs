using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f; 
    [SerializeField] private float maxZ = 130f; // Максимальная граница

   // private Animator animator;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y, maxZ), playerSpeed * Time.deltaTime);

    }
}
