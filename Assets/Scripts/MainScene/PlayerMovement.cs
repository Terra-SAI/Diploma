using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private float playerSpeed = 10f;
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        cameraManager.isOnMain = true;
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        if (!cameraManager.isOnMain) return;
        
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude > 0.01f)
        {
            animator.SetBool("isWalking", true);
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.transform.rotation = targetRotation;
            rb.AddForce(movement * playerSpeed);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
