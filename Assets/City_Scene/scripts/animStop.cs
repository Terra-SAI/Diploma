using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStop : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject PC;
    [SerializeField] private float z = 5.0f;
    // private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.transform.position.z < z)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

    }
}
